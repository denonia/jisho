using System.Text;
using System.Text.Json;
using Jisho.WebApi.Responses.External;

namespace Jisho.WebApi.Services;

public class ReversoService
{
    private const string ContextUrl = "https://context.reverso.net/bst-query-service";

    private readonly IHttpClientFactory _httpClientFactory;

    public ReversoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ReversoContextResponse?> GetContext(string query, int page)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");

        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                source_text = query,
                target_text = "",
                source_lang = "ja",
                target_lang = "en",
                npage = page
            }),
            Encoding.UTF8,
            "application/json");

        var response = await httpClient.PostAsync(ContextUrl, jsonContent);
        var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<ReversoContextResponse>(stream);
        return result;
    }
}