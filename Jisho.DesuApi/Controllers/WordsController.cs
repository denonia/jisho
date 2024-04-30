using Jisho.DesuApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jisho.DesuApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsController : ControllerBase
{
    private readonly DesuService _desuService;

    public WordsController(DesuService desuService)
    {
        _desuService = desuService;
    }

    [HttpGet]
    public IActionResult SearchWords(string query = "")
    {
        var result = _desuService.JapaneseEntries
            .Where(x => x.Kanjis.Any(k => k.Text.Contains(query)));
        
        var resultReadings = _desuService.JapaneseEntries
            .Where(x => x.Readings.Any(k => k.Text.Contains(query)));

        var resultTranslations = _desuService.JapaneseEntries
            .Where(x => x.Senses.SelectMany(s => s.Glosses).Any(g => g.Term.StartsWith(query)));
            

        return Ok(result.Concat(resultReadings).Concat(resultTranslations));
    }
}