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
public class PostController : ControllerBase
{
    private BandBlendDbContext _dbContext;


    public PostController(BandBlendDbContext context)
    {
        _dbContext = context;

    }

    [HttpGet("user/{id}")]
    [Authorize]
    public IActionResult GetUserPosts(int id)
    {
        return Ok(_dbContext.Posts
        .Where(p => p.UserProfileId == id)
        .OrderBy(p => p.Date)
        .ToList());
    }



}