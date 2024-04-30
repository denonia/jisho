using Wacton.Desu.Japanese;
using Wacton.Desu.Kanji;
using Wacton.Desu.Radicals;

namespace Jisho.DesuApi.Services;

public class DesuService
{
    public IEnumerable<IJapaneseEntry?> JapaneseEntries { get; set; }
    // public IEnumerable<INameEntry?> NameEntries { get; set; }
    public IEnumerable<IKanjiEntry?> KanjiEntries { get; set; }
    public IDictionary<string, IEnumerable<string>> RadicalToKanjis { get; set; }

    public async Task Initialize()
    {
        JapaneseEntries = await JapaneseDictionary.ParseEntriesAsync(); 
        // NameEntries = await NameDictionary.ParseEntriesAsync();
        KanjiEntries = await KanjiDictionary.ParseEntriesAsync();
        RadicalToKanjis = await RadicalLookup.ParseRadicalToKanjisAsync();
    }
}