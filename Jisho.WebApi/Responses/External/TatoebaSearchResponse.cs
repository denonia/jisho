using System.Text.Json.Serialization;

namespace Jisho.WebApi.Responses.External;

public class Paging
{
    [JsonPropertyName("Sentences")] public Sentences Sentences { get; set; }
}

public class Result
{
    [JsonPropertyName("id")] public int? Id { get; set; }

    [JsonPropertyName("text")] public string Text { get; set; }

    [JsonPropertyName("lang")] public string Lang { get; set; }

    [JsonPropertyName("correctness")] public int? Correctness { get; set; }

    [JsonPropertyName("script")] public object Script { get; set; }

    [JsonPropertyName("license")] public string License { get; set; }

    [JsonPropertyName("translations")] public List<List<Result>> Translations { get; set; }

    [JsonPropertyName("transcriptions")] public List<Transcription> Transcriptions { get; set; }

    [JsonPropertyName("audios")] public List<object> Audios { get; set; }

    [JsonPropertyName("user")] public User User { get; set; }

    [JsonPropertyName("lang_name")] public string LangName { get; set; }

    [JsonPropertyName("dir")] public string Dir { get; set; }

    [JsonPropertyName("lang_tag")] public string LangTag { get; set; }

    [JsonPropertyName("is_favorite")] public object IsFavorite { get; set; }

    [JsonPropertyName("is_owned_by_current_user")]
    public bool? IsOwnedByCurrentUser { get; set; }

    [JsonPropertyName("permissions")] public object Permissions { get; set; }

    [JsonPropertyName("max_visible_translations")]
    public int? MaxVisibleTranslations { get; set; }

    [JsonPropertyName("current_user_review")]
    public object CurrentUserReview { get; set; }
}

public class TatoebaSearchResponse
{
    [JsonPropertyName("paging")] public Paging Paging { get; set; }

    [JsonPropertyName("results")] public List<Result> Results { get; set; }
}

public class Sentences
{
    [JsonPropertyName("finder")] public string Finder { get; set; }

    [JsonPropertyName("page")] public int? Page { get; set; }

    [JsonPropertyName("current")] public int? Current { get; set; }

    [JsonPropertyName("count")] public int? Count { get; set; }

    [JsonPropertyName("perPage")] public int? PerPage { get; set; }

    [JsonPropertyName("start")] public int? Start { get; set; }

    [JsonPropertyName("end")] public int? End { get; set; }

    [JsonPropertyName("prevPage")] public bool? PrevPage { get; set; }

    [JsonPropertyName("nextPage")] public bool? NextPage { get; set; }

    [JsonPropertyName("pageCount")] public int? PageCount { get; set; }

    [JsonPropertyName("sort")] public object Sort { get; set; }

    [JsonPropertyName("direction")] public object Direction { get; set; }

    [JsonPropertyName("limit")] public object Limit { get; set; }

    [JsonPropertyName("sortDefault")] public bool? SortDefault { get; set; }

    [JsonPropertyName("directionDefault")] public bool? DirectionDefault { get; set; }

    [JsonPropertyName("scope")] public object Scope { get; set; }

    [JsonPropertyName("completeSort")] public List<object> CompleteSort { get; set; }
}

public class Transcription
{
    [JsonPropertyName("id")] public int? Id { get; set; }

    [JsonPropertyName("sentence_id")] public int? SentenceId { get; set; }

    [JsonPropertyName("script")] public string Script { get; set; }

    [JsonPropertyName("text")] public string Text { get; set; }

    [JsonPropertyName("user_id")] public int? UserId { get; set; }

    [JsonPropertyName("needsReview")] public bool? NeedsReview { get; set; }

    [JsonPropertyName("modified")] public DateTime? Modified { get; set; }

    [JsonPropertyName("user")] public User User { get; set; }

    [JsonPropertyName("readonly")] public bool? Readonly { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("html")] public string Html { get; set; }

    [JsonPropertyName("markup")] public object Markup { get; set; }

    [JsonPropertyName("info_message")] public string InfoMessage { get; set; }
}

public class User
{
    [JsonPropertyName("username")] public string Username { get; set; }
}