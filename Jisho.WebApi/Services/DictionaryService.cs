using Jisho.WebApi.Data;
using Jisho.WebApi.Entities;

namespace Jisho.WebApi.Services;

public class DictionaryService
{
    private readonly AppDbContext _dbContext;

    public DictionaryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<DictionaryEntry>> FindEntriesAsync(string query)
    {
        return _dbContext.DictionaryEntries.Where(x =>
                x.Term.Contains(query) || x.Reading.Contains(query))
            .OrderByDescending(x => x.Popularity)
            .ToList();
    }
}