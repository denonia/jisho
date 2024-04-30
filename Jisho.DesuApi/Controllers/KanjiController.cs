using Jisho.DesuApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jisho.DesuApi.Controllers;

[ApiController]
[Route("[controller]")]
public class KanjiController : ControllerBase
{
    private readonly DesuService _desuService;

    public KanjiController(DesuService desuService)
    {
        _desuService = desuService;
    }

    [HttpGet("radicals")]
    public IActionResult GetRadicals()
    {
        return Ok(_desuService.RadicalToKanjis.Keys);
    }

    [HttpGet]
    public IActionResult SearchKanji(string query = "", string radicals = "")
    {
        if (string.IsNullOrEmpty(query) && string.IsNullOrEmpty(radicals))
            return BadRequest("At least one filter is required.");

        var result = _desuService.KanjiEntries;

        if (!string.IsNullOrEmpty(query))
            result = result.Where(x => x.Literal == query);

        if (!string.IsNullOrEmpty(radicals))
        {
            var radicalList = radicals.Split(' ');

            result = result.Where(x =>
                x.RadicalDecomposition.Intersect(radicalList).Count() == radicalList.Length);
        }

        return Ok(result);
    }
}