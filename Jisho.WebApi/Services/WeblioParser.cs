using HtmlAgilityPack;
using Jisho.WebApi.Responses;

namespace Jisho.WebApi.Services;

public class WeblioParser
{
    private const string SentenceUrl = "https://ejje.weblio.jp/sentence/content/{0}/{1}";

    private readonly IHttpClientFactory _httpClientFactory;

    public WeblioParser(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<SentencesResponse> GetSentences(string query, int page)
    {
        var client = _httpClientFactory.CreateClient();
        var url = string.Format(SentenceUrl, query, page);
        var response = await client.GetStreamAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.Load(response);

        var root = htmlDocument.DocumentNode;

        var totalResultsNode = root.SelectSingleNode("//p[@class=\"qotHTR\"]//b");
        if (totalResultsNode is null)
            return EmptyResponse();

        var totalResults =
            Convert.ToInt32(totalResultsNode.InnerText);

        var pageSelectors = root
            .SelectNodes("//div[@class=\"pgntionWrp\"]//*[self::a or self::span]");

        var pages = pageSelectors is null
            ? 1
            : Convert.ToInt32(
                pageSelectors
                    .TakeLast(2)
                    .Select(x => x.InnerText.Trim())
                    .Last(x => x != "次へ\uff1e"));

        var japaneseEntryNodes = root.SelectNodes("//p[@class=\"qotCJJ\"]");
        if (japaneseEntryNodes is null)
            return EmptyResponse();

        var japaneseEntries = japaneseEntryNodes
            .Select(x => x.InnerText.Replace("例文帳に追加", "").Trim());

        var englishEntries = root.SelectNodes("//p[@class=\"qotCJE\"]")
            .Select(x => x.InnerText[..x.InnerText.IndexOf("&nbsp", StringComparison.InvariantCulture)].Trim());

        var dict = japaneseEntries.Zip(englishEntries)
            .DistinctBy(x => x.First)
            .ToDictionary(x => x.First, y => y.Second);

        return new SentencesResponse
        {
            TotalResults = totalResults,
            Pages = pages,
            Entries = dict
        };
    }

    private static SentencesResponse EmptyResponse() =>
        new SentencesResponse
            { TotalResults = 0, Pages = 0, Entries = new Dictionary<string, string>() };
}