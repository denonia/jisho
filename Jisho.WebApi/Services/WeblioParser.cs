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

    public async Task<WeblioSentencesResponse> GetSentences(string query, int page)
    {
        var client = _httpClientFactory.CreateClient();
        var url = string.Format(SentenceUrl, query, page);
        var response = await client.GetStreamAsync(url);

        var htmlDocument = new HtmlDocument();
        htmlDocument.Load(response);

        var totalResults =
            Convert.ToInt32(htmlDocument.DocumentNode.SelectSingleNode("//p[@class=\"qotHTR\"]//b").InnerText);

        var pages = Convert.ToInt32(
            htmlDocument.DocumentNode
            .SelectNodes("//div[@class=\"pgntionWrp\"]//*[self::a or self::span]")
            .TakeLast(2)
            .Select(x => x.InnerText.Trim())
            .Last(x => x != "次へ\uff1e"));

        var japaneseEntries = htmlDocument.DocumentNode.SelectNodes("//p[@class=\"qotCJJ\"]")
            .Select(x => x.InnerText.Replace("例文帳に追加", "").Trim());

        var englishEntries = htmlDocument.DocumentNode.SelectNodes("//p[@class=\"qotCJE\"]")
            .Select(x => x.InnerText[..x.InnerText.IndexOf("&nbsp", StringComparison.InvariantCulture)].Trim());

        var dict = japaneseEntries.Zip(englishEntries)
            .DistinctBy(x => x.First)
            .ToDictionary(x => x.First, y => y.Second);

        return new WeblioSentencesResponse
        {
            TotalResults = totalResults,
            Pages = pages,
            Entries = dict
        };
    }
}