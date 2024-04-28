using Jisho.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jisho.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeblioController : ControllerBase
{
    private readonly WeblioParser _weblioParser;

    public WeblioController(WeblioParser weblioParser)
    {
        _weblioParser = weblioParser;
    }

    [HttpGet("sentences")]
    public async Task<IActionResult> GetSentences(string query, int page = 1)
    {
        return Ok(await _weblioParser.GetSentences(query, page));
    }
}