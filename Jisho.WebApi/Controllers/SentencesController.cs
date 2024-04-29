using System.Text;
using Jisho.WebApi.Responses;
using Jisho.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jisho.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SentencesController : ControllerBase
{
    private readonly WeblioParser _weblioParser;
    private readonly ReversoService _reversoService;
    private readonly TatoebaService _tatoebaService;

    public SentencesController(WeblioParser weblioParser, ReversoService reversoService, TatoebaService tatoebaService)
    {
        _weblioParser = weblioParser;
        _reversoService = reversoService;
        _tatoebaService = tatoebaService;
    }

    [HttpGet("weblio")]
    public async Task<IActionResult> GetWeblioSentences(string query, int page = 1)
    {
        return Ok(await _weblioParser.GetSentences(query, page));
    }

    [HttpGet("reverso")]
    public async Task<IActionResult> GetReversoSentences(string query, int page = 1)
    {
        var context = await _reversoService.GetContext(query, page);

        var entries = context.List
            .Select(x => (RemoveTags(x.SText), RemoveTags(x.TText)))
            .DistinctBy(x => x.Item1)
            .ToDictionary();

        var response = new SentencesResponse
        {
            Pages = context.Npages ?? 1,
            TotalResults = context.Nrows ?? 0,
            Entries = entries
        };

        return Ok(response);
    }

    [HttpGet("tatoeba")]
    public async Task<IActionResult> GetTatoebaSentences(string query, int page = 1)
    {
        var result = await _tatoebaService.GetSentences(query, page);

        var entries = result.Results
            .Select(x => (x.Text, x.Translations[0][0].Text))
            .DistinctBy(x => x.Item1)
            .ToDictionary();

        var totalResults = result.Paging.Sentences.Count ?? 0;
        var perPage = result.Paging.Sentences.PerPage ?? 10;

        var response = new SentencesResponse
        {
            TotalResults = totalResults,
            Pages = (totalResults - 1) / perPage + 1,
            Entries = entries
        };

        return Ok(response);
    }

    private string RemoveTags(string str) => new StringBuilder(str)
        .Replace("<em>", "")
        .Replace("</em>", "")
        .ToString();
}