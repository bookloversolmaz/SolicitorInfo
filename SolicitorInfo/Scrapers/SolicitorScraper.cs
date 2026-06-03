using SolicitorInfo.Models;

namespace SolicitorInfo.Scrapers
{
    public class SolicitorScraper
    {
        private readonly HttpClient _httpClient;

        public SolicitorScraper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SolicitorItem>> ScrapeAsync(string location)
        {
            var results = new List<SolicitorItem>();

            string url = $"https://www.solicitors.com/{location}-solicitors.html";

            string html = await _httpClient.GetStringAsync(url);

            return results;
        }

    }
}