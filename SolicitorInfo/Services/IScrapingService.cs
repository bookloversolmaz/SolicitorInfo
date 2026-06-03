using SolicitorInfo.Models;

namespace SolicitorInfo.Repository
{

    public interface IScrapingService
    {
        Task<List<SolicitorItem>> ScrapeLocationsAsync(List<string> locations);
    }

}