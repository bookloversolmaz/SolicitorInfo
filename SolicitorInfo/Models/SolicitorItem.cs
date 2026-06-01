namespace SolicitorInfo.Models;

public class SolicitorItem
{
    public long Id {get; set;}
    public required string SolicitorName {get; set;}
    public required string Location {get; set;}
    public required string Email {get; set;}
    public required string PhoneNumber {get; set;}
    public required string Address {get; set;}
}