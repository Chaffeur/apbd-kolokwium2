using kolokwium2.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class batchesController : ControllerBase
{
    
    private readonly IAddTreeService _service;

    public batchesController(IAddTreeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddTree([FromBody] TreesDTO trees)
    {
        try
        {
            await _service.AddTree(trees);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
        

        return Ok("Success");
    }
    
    
    
}