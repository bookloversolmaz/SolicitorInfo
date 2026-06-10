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
    public async Task<ActionResult<List<SolicitorItem>>> Get()
    {
        var items = await _solicitorRepository.GetAllAsync();

        return Ok(items);
    }
}