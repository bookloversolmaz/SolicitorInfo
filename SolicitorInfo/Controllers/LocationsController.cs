using Microsoft.AspNetCore.Mvc;
using SolicitorInfo.Services;

namespace SolicitorInfo.Controllers;

[ApiController]
[Route("api/solicitors")]
public class LocationsController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationsController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("locations")]
    public IActionResult GetLocations()
    {
        return Ok(_locationService.GetLocations());
    }
}