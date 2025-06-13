using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
public class nurseriesController : ControllerBase
{

    private readonly INurseService _service;

    public nurseriesController(INurseService service)
    {
        _service = service;
    }

    [HttpGet("api/[controller]/{id}/batches")]
    
    public async Task<ActionResult> GetNurseries(int id)
    {
        
        var result = await _service.GetNurseries(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

}