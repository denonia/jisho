using Microsoft.AspNetCore.Mvc;

namespace Jisho.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeblioController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeblioController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTerms()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetStringAsync("https://ejje.weblio.jp/sentence/content/密度");

        return Ok(response);
    }
}