namespace SolicitorInfo.Models;

public class SolicitorItem
{
    public long Id {get; set;}
    public required string SolicitorName {get; set;}
    public required string Location {get; set;}

    // PhysicalLocation differs from location as location is one of the eight cities listed in the task, whereas
    // PhysicalLocation is where they are actually based i.e Location = London, PhysicalLocation = Croydon.
    public required string PhysicalLocation { get; set; }
    public string? Email {get; set;}
    public required string PhoneNumber {get; set;}
    public required string Address {get; set;}
    public string? Website {get; set;}
    public decimal? Rating {get; set;}
    public DateTime ScrapedAt {get; set;}

    // Some of the properties above are nullable as I can see from solicitors.com that those typses of data aren't
    // included with every firm.

}