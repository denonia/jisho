using System.IO.Compression;
using System.Text.Json;
using Npgsql;

namespace Jisho.WebApi.Data;

public class YomichanDictionarySeeder
{
    public static void Seed(AppDbContext dbContext, IConfiguration configuration, ILogger logger)
    {
        if (!dbContext.DictionaryEntries.Any())
        {
            logger.LogInformation("Initializing dictionary entries database..");
            SeedEntries(configuration, logger);
        }
    }

    public static void SeedEntries(IConfiguration configuration, ILogger logger)
    {
        var connectionString = configuration.GetRequiredSection("ConnectionStrings")["DefaultConnection"];
        var dictionaryPath = configuration["YomichanDictionaryPath"];

        using var dictionaryFile = File.OpenRead(dictionaryPath);
        using var zip = new ZipArchive(dictionaryFile, ZipArchiveMode.Read);

        foreach (var zipEntry in zip.Entries)
        {
            if (zipEntry.Name.StartsWith("term_bank_"))
            {
                var stream = zipEntry.Open();

                var json = JsonSerializer.Deserialize<List<List<JsonElement>>>(stream);

                var banks = Directory.GetFiles(Environment.CurrentDirectory, "term_bank_*.json");

                logger.LogInformation(
                    $"Inserting rows from {zipEntry.Name}: {json.Count}");

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (var writer = conn.BeginBinaryImport("copy public.\"DictionaryEntries\" from STDIN (FORMAT BINARY)"))
                    {
                        foreach (var entry in json)
                        {
                            writer.StartRow();
                            writer.Write(Guid.NewGuid());
                            writer.Write(entry[0].GetString()!, NpgsqlTypes.NpgsqlDbType.Varchar);
                            writer.Write(entry[1].GetString()!, NpgsqlTypes.NpgsqlDbType.Varchar);
                            writer.Write(entry[2].GetString()!, NpgsqlTypes.NpgsqlDbType.Varchar);
                            writer.Write(entry[3].GetString()!, NpgsqlTypes.NpgsqlDbType.Varchar);
                            writer.Write(entry[4].GetInt32(), NpgsqlTypes.NpgsqlDbType.Integer);
                            writer.Write(entry[5].GetRawText(), NpgsqlTypes.NpgsqlDbType.Varchar);
                            writer.Write(entry[6].GetInt32(), NpgsqlTypes.NpgsqlDbType.Integer);
                        }

                        writer.Complete();
                    }
                }

                logger.LogInformation("Inserting finished");
            }
        }
    }
}