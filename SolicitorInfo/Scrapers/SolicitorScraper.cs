using SolicitorInfo.Models;

namespace SolicitorInfo.Scrapers
{
    public class SolicitorScraper
    {
        private readonly HttpClient _httpClient;

        private readonly SolicitorContext _solicitorContext;
        
        public SolicitorScraper(HttpClient httpClient, SolicitorContext solicitorContext)
        {
            _httpClient = httpClient;
            _solicitorContext = solicitorContext;

            // added this so that the request looks like a browse to prevent rejction from the website
            _httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 Chrome/120 Safari/537.36");
        }
        // 1. Download the HTML page
        public async Task<List<SolicitorItem>> ScrapeAsync(string location)
        {
            
            // Clear old data first
            _solicitorContext.SolicitorItems.RemoveRange(_solicitorContext.SolicitorItems);
            await _solicitorContext.SaveChangesAsync();

            var results = new List<SolicitorItem>();
            
            // Build URL for the location search
            var url = $"https://www.solicitors.com/conveyancing+{location.ToLower()}.html";

            // Download raw HTML from website
            var html = await _httpClient.GetStringAsync(url);

            // constant used to prevent the existing values from being overwritten
            const string marker = "<div class=\"result-item\">";

            int currentIndex = 0;

            // 2. Find each solicitor listing
            while (true)
            {
                // IndexOf returns the first occurance of the result item
                var startIndex = html.IndexOf(marker, currentIndex);

                if (startIndex == -1)
                {
                    break;
                }

                // this then finds the next occurance of a result item. Find the next one
                // as we want the inbfo between the first and second result item
                var nextIndex = html.IndexOf(marker, startIndex + marker.Length);

                // create a string block for one solicitor, a block class that contains the solicitor's html data.
                string block;

                if (nextIndex == -1)
                {
                    // if this is the last class block, extract everything from startIndex to the end of the page
                    block = html[startIndex..];
                }
                else
                {
                    // otherwise extract from this block to the next
                    block = html[startIndex..nextIndex];
                }
                
                // parse data
                var solicitor = ParseSolicitor(block, location);

                // add results to solicitor
                if (solicitor != null)
                {
                    results.Add(solicitor);
                }

                // move to next solicitor, which is the length of the result item, loop until it reaches the end (-1)
                currentIndex = startIndex + marker.Length;
            }
        
        // save the new results
        await _solicitorContext.SolicitorItems.AddRangeAsync(results);
        await _solicitorContext.SaveChangesAsync();

        return results;
    }

    // 3. Extract data from each listing. Convert html to solicitorItem
    private SolicitorItem? ParseSolicitor(string block, string location)
    {
        var name = ExtractBetween(
            block,
            "<span class=\"h2\">",
            "<div class=\"greentick\"");

        var address = ExtractBetween(
            block,
            "<address>",
            "</address>");

        var website = ExtractHrefAfter(
            block,
            "<i class=\"fa fa-globe\"");

        var phone = ExtractBetween(
            block,
            "href=\"tel:",
            "\"");

        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        // 4. Convert it into a SolicitorItem object
        return new SolicitorItem
        {
            SolicitorName = HtmlDecode(name),
            Location = location,
            PhysicalLocation = location,
            Address = HtmlDecode(address ?? string.Empty),
            PhoneNumber = phone ?? string.Empty,
            Website = website,
            Email = null,
            Rating = null,
            ScrapedAt = DateTime.UtcNow
        };
    }

    // How to extract the info that is between html
    private static string? ExtractBetween(
        string source,
        string startText,
        string endText)
    {
        var start = source.IndexOf(startText);

        if (start == -1)
        {
            return null;
        }

        // start after the html arrows
        start += startText.Length;

        var end = source.IndexOf(endText, start);

        if (end == -1)
        {
            return null;
        }

        // 
        return source[start..end].Trim();
    }

    private static string? ExtractHrefAfter(
        string source,
        string marker)
    {
        var markerIndex = source.IndexOf(marker);

        if (markerIndex == -1)
        {
            return null;
        }

        var hrefStart = source.IndexOf("href=\"", markerIndex);

        if (hrefStart == -1)
        {
            return null;
        }

        // <a href is 6 chars
        hrefStart += 6;

        var hrefEnd = source.IndexOf("\"", hrefStart);

        if (hrefEnd == -1)
        {
            return null;
        }

        return source[hrefStart..hrefEnd];
    }

        // 5. Return a list of SolicitorItems
        private static string HtmlDecode(string value)
        {
            return System.Net.WebUtility.HtmlDecode(value);
        }
    }
}