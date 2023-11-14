using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BandBlend.Data;
using Microsoft.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
    [Authorize]
    public IActionResult GetPrimaryInstruments()
    {
        return Ok(_dbContext.PrimaryInstruments);
    }


}