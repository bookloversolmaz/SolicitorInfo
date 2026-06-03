using SolicitorInfo.Models;
using SolicitorInfo.Scrapers;

namespace SolicitorInfo.Repository;
public class ScrapingService : IScrapingService
{
    private readonly SolicitorScraper _solicitorScraper;

    private readonly ISolicitorRepository _solicitorRepository;

    public ScrapingService(
        SolicitorScraper solicitorScraper,
        ISolicitorRepository solicitorRepository)
    {
        _solicitorScraper = solicitorScraper;
        _solicitorRepository = solicitorRepository;
    }

    // Loops through locations, scrapes info, saves the info and returns the results
    public async Task<List<SolicitorItem>> ScrapeLocationsAsync(List<string> locations)
    {
        var results = new List<SolicitorItem>();

        foreach (var location in locations)
        {
            var solicitors = await _solicitorScraper.ScrapeAsync(location);
            results.AddRange(solicitors);
        }

        await _solicitorRepository.AddRangeAsync(results);

        return results;
    }
}