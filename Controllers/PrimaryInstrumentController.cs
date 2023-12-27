using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;

namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PrimaryInstrumentController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public PrimaryInstrumentController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetPrimaryInstruments()
    {
        return Ok(_dbContext.PrimaryInstruments);
    }


}