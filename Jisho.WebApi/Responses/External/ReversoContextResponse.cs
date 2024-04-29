using System.Text.Json.Serialization;

namespace Jisho.WebApi.Responses.External;

public class DictionaryEntryList
{
    [JsonPropertyName("frequency")] public int? Frequency { get; set; }

    [JsonPropertyName("term")] public string Term { get; set; }

    [JsonPropertyName("isFromDict")] public bool? IsFromDict { get; set; }

    [JsonPropertyName("isPrecomputed")] public bool? IsPrecomputed { get; set; }

    [JsonPropertyName("stags")] public List<string> Stags { get; set; }

    [JsonPropertyName("article")] public string Article { get; set; }

    [JsonPropertyName("pos")] public string Pos { get; set; }

    [JsonPropertyName("sourcepos")] public List<string> Sourcepos { get; set; }

    [JsonPropertyName("variant")] public object Variant { get; set; }

    [JsonPropertyName("domain")] public object Domain { get; set; }

    [JsonPropertyName("definition")] public object Definition { get; set; }

    [JsonPropertyName("vowels1")] public object Vowels1 { get; set; }

    [JsonPropertyName("transliteration1")] public string Transliteration1 { get; set; }

    [JsonPropertyName("vowels2")] public object Vowels2 { get; set; }

    [JsonPropertyName("transliteration2")] public object Transliteration2 { get; set; }

    [JsonPropertyName("alignFreq")] public int? AlignFreq { get; set; }

    [JsonPropertyName("reverseValidated")] public bool? ReverseValidated { get; set; }

    [JsonPropertyName("pos_group")] public int? PosGroup { get; set; }

    [JsonPropertyName("isTranslation")] public bool? IsTranslation { get; set; }

    [JsonPropertyName("isFromLOCD")] public bool? IsFromLOCD { get; set; }

    [JsonPropertyName("inflectedForms")] public List<object> InflectedForms { get; set; }

    [JsonPropertyName("isHiddenInFirstView")]
    public bool? IsHiddenInFirstView { get; set; }
}

public class List
{
    [JsonPropertyName("s_text")] public string SText { get; set; }

    [JsonPropertyName("t_text")] public string TText { get; set; }

    [JsonPropertyName("ref")] public string Ref { get; set; }

    [JsonPropertyName("cname")] public string Cname { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("ctags")] public string Ctags { get; set; }

    [JsonPropertyName("pba")] public bool? Pba { get; set; }
}

public class Request
{
    [JsonPropertyName("source_text")] public string SourceText { get; set; }

    [JsonPropertyName("target_text")] public string TargetText { get; set; }

    [JsonPropertyName("source_lang")] public string SourceLang { get; set; }

    [JsonPropertyName("target_lang")] public string TargetLang { get; set; }

    [JsonPropertyName("npage")] public int? Npage { get; set; }

    [JsonPropertyName("corpus")] public object Corpus { get; set; }

    [JsonPropertyName("nrows")] public int? Nrows { get; set; }

    [JsonPropertyName("adapted")] public bool? Adapted { get; set; }

    [JsonPropertyName("nonadapted_text")] public string NonadaptedText { get; set; }

    [JsonPropertyName("rude_words")] public bool? RudeWords { get; set; }

    [JsonPropertyName("colloquialisms")] public bool? Colloquialisms { get; set; }

    [JsonPropertyName("risky_words")] public bool? RiskyWords { get; set; }

    [JsonPropertyName("mode")] public int? Mode { get; set; }

    [JsonPropertyName("expr_sug")] public int? ExprSug { get; set; }

    [JsonPropertyName("dym_apply")] public bool? DymApply { get; set; }

    [JsonPropertyName("pos_reorder")] public int? PosReorder { get; set; }

    [JsonPropertyName("device")] public int? Device { get; set; }

    [JsonPropertyName("split_long")] public bool? SplitLong { get; set; }

    [JsonPropertyName("has_locd")] public bool? HasLocd { get; set; }

    [JsonPropertyName("avoidLOCD")] public bool? AvoidLOCD { get; set; }

    [JsonPropertyName("source_pos")] public object SourcePos { get; set; }

    [JsonPropertyName("toolwordRequest")] public bool? ToolwordRequest { get; set; }
}

public class ReversoContextResponse
{
    [JsonPropertyName("list")] public List<List> List { get; set; }

    [JsonPropertyName("nrows")] public int? Nrows { get; set; }

    [JsonPropertyName("nrows_exact")] public int? NrowsExact { get; set; }

    [JsonPropertyName("pagesize")] public int? Pagesize { get; set; }

    [JsonPropertyName("npages")] public int? Npages { get; set; }

    [JsonPropertyName("page")] public int? Page { get; set; }

    [JsonPropertyName("removed_superstrings")]
    public List<string> RemovedSuperstrings { get; set; }

    [JsonPropertyName("dictionary_entry_list")]
    public List<DictionaryEntryList> DictionaryEntryList { get; set; }

    [JsonPropertyName("dictionary_other_frequency")]
    public int? DictionaryOtherFrequency { get; set; }

    [JsonPropertyName("dictionary_nrows")] public int? DictionaryNrows { get; set; }

    [JsonPropertyName("time_ms")] public int? TimeMs { get; set; }

    [JsonPropertyName("request")] public Request Request { get; set; }

    [JsonPropertyName("suggestions")] public List<SuggestionObj> Suggestions { get; set; }

    [JsonPropertyName("dym_case")] public int? DymCase { get; set; }

    [JsonPropertyName("dym_applied")] public object DymApplied { get; set; }

    [JsonPropertyName("dym_nonadapted_search")]
    public object DymNonadaptedSearch { get; set; }

    [JsonPropertyName("dym_pair_applied")] public object DymPairApplied { get; set; }

    [JsonPropertyName("dym_nonadapted_search_pair")]
    public object DymNonadaptedSearchPair { get; set; }

    [JsonPropertyName("dym_pair")] public object DymPair { get; set; }

    [JsonPropertyName("extracted_phrases")]
    public List<object> ExtractedPhrases { get; set; }

    [JsonPropertyName("sourceTransliterations")]
    public List<object> SourceTransliterations { get; set; }

    [JsonPropertyName("dym_list")] public List<string> DymList { get; set; }
}

public class SuggestionObj
{
    [JsonPropertyName("lang")] public string Lang { get; set; }

    [JsonPropertyName("suggestion")] public string Suggestion { get; set; }

    [JsonPropertyName("weight")] public int? Weight { get; set; }

    [JsonPropertyName("isFromDict")] public bool? IsFromDict { get; set; }
}