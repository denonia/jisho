
namespace Jisho.WebApi.Responses;

public class DictionaryEntryResponse
{
    public string Term { get; set; }
    public string Reading { get; set; }
    public string Tags { get; set; }
    public string Deinflectors { get; set; }
    public int Popularity { get; set; }
    public object[] Definitions { get; set; }
    public int Sequence { get; set; }
}