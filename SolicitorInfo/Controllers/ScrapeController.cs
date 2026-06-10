using Microsoft.AspNetCore.Mvc;
using SolicitorInfo.Models;
using SolicitorInfo.Repository;

namespace Scrape.Controllers
{
    [ApiController]
    [Route("api/scrape")]
    public class ScrapeController : ControllerBase
    {
        private readonly IScrapingService _scrapingService;

        public ScrapeController(IScrapingService scrapingService)
        {
            _scrapingService = scrapingService;
        }

        // Starts scraping process
        [HttpPost]
        public async Task<ActionResult<List<SolicitorItem>>> Scrape([FromBody] List<string> locations)
        {
            var results = await _scrapingService.ScrapeLocationsAsync(locations);

            return Ok(results);
        }

    }

}

