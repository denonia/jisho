using System.Text.Json;
using Jisho.WebApi.Responses;
using Jisho.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jisho.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController : ControllerBase
{
    private readonly DictionaryService _dictionaryService;

    public DictionaryController(DictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
    }

    [HttpGet]
    public async Task<IActionResult> FindEntries(string query)
    {
        var entries = await _dictionaryService.FindEntriesAsync(query);
        
        var response = entries.Select(x => new DictionaryEntryResponse
        {
            Term = x.Term,
            Reading = x.Reading,
            Tags = x.Tags,
            Deinflectors = x.Deinflectors,
            Popularity = x.Popularity,
            Definitions = JsonSerializer.Deserialize<object[]>(x.Definitions),
            Sequence = x.Sequence
        });
        
        return Ok(response);
    }
}