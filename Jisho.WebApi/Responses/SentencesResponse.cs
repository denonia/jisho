namespace Jisho.WebApi.Responses;

public class SentencesResponse
{
    public required int TotalResults { get; set; }
    public required int Pages { get; set; }
    public required IDictionary<string, string> Entries { get; set; }
}