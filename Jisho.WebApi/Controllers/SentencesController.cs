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

    public SentencesController(WeblioParser weblioParser, ReversoService reversoService)
    {
        _weblioParser = weblioParser;
        _reversoService = reversoService;
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

    private string RemoveTags(string str) => new StringBuilder(str)
        .Replace("<em>", "")
        .Replace("</em>", "")
        .ToString();
}