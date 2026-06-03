using Microsoft.AspNetCore.Mvc;
using SolicitorInfo.Models;
using SolicitorInfo.Repository;

namespace Scrape.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapeController : ControllerBase
    {
        private readonly IScrapingService _scrapingService;

        public ScrapeController(IScrapingService scrapingService)
        {
            _scrapingService = scrapingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is working");
        }

        [HttpPost]
        public async Task<IActionResult> Scrape([FromBody] List<string> locations)
        {
            var results = await _scrapingService.ScrapeLocationsAsync(locations);

            return Ok(results);
        }

    }

}

