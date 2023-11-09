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
    private readonly UserManager<IdentityUser> _userManager;


    public PostController(BandBlendDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;

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