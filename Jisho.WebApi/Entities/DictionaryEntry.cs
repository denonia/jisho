namespace Jisho.WebApi.Entities;

public class DictionaryEntry
{
    public Guid Id { get; set; }
    public string Term { get; set; }
    public string Reading { get; set; }
    public string Tags { get; set; }
    public string Deinflectors { get; set; }
    public int Popularity { get; set; }
    public string Definitions { get; set; }
    public int Sequence { get; set; }
}