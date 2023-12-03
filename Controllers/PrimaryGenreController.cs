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