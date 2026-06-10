namespace SolicitorInfo.Services;

public class LocationService
{
    public List<string> GetLocations()
    {
        return new List<string>
        {
            "London",
            "Manchester",
            "Leeds",
            "Birmingham",
            "Liverpool",
            "Bristol",
            "Sheffield",
            "Nottingham"
        };
    }
}