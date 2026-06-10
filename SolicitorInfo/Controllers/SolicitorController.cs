using Microsoft.AspNetCore.Mvc;
using SolicitorInfo.Models;
using SolicitorInfo.Repository;

namespace SolicitorInfo.Controllers;

[ApiController]
[Route("api/solicitors")]
public class SolicitorsController : ControllerBase
{
    private readonly ISolicitorRepository _solicitorRepository;

    public SolicitorsController(ISolicitorRepository solicitorRepository)
    {
        _solicitorRepository = solicitorRepository;
    }

    // Returns all stored solicitors from DB
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? location)
    {
        var data = _solicitorRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(location))
        {
            data = data
                .Where(x => x.Location.Contains(location))
                .ToList();
        }

        return Ok(data);
    }

}