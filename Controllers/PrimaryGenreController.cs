using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;


namespace BandBlend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PrimaryGenreController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public PrimaryGenreController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetPrimaryGenress()
    {
        return Ok(_dbContext.PrimaryGenres);
    }


}