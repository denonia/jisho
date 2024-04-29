using System.Net.Http.Headers;
using System.Text.Json;
using Jisho.WebApi.Responses.External;

namespace Jisho.WebApi.Services;

public class TatoebaService
{
    private const string SearchUrl = "https://tatoeba.org/eng/api_v0/search";

    private readonly IHttpClientFactory _httpClientFactory;

    public TatoebaService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<TatoebaSearchResponse?> GetSentences(string query, int page)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var queryParameters = new Dictionary<string, string>
        {
            { "from", "jpn" },
            { "to", "eng" },
            { "trans_to", "eng" },
            { "trans_filter", "limit" },
            { "trans_link", "direct" },
            { "query", query },
            { "page", page.ToString() },
        };
        var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
        var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

        var response = await httpClient.GetAsync($"{SearchUrl}?{queryString}");
        var stream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<TatoebaSearchResponse>(stream);
        return result;
    }
}