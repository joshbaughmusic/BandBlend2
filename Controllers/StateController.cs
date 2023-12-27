using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;

namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StateController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public StateController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetStates()
    {
       return Ok(_dbContext.States);
    }


}