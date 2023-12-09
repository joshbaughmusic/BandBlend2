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
public class BlockedAccountController : ControllerBase
{
    private BandBlendDbContext _dbContext;

    public BlockedAccountController(BandBlendDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetBlockedAccounts()
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<BlockedAccount> userBlockedAccounts = _dbContext.BlockedAccounts
        .Include(ba => ba.BlockedUserProfile)
        .ThenInclude(up => up.Profile)
        .Where(ba => ba.UserProfileThatBlockedId == loggedInUser.Id)
        .ToList();

        return Ok(userBlockedAccounts);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult UnblockAccount(int id)
    {
        BlockedAccount foundBlockedAccount = _dbContext.BlockedAccounts.SingleOrDefault(ba => ba.Id == id);

        if (foundBlockedAccount == null)
        {
            return NotFound();
        }

        _dbContext.BlockedAccounts.Remove(foundBlockedAccount);

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("{id}")]
    [Authorize]
    public IActionResult BlockAccount(int id)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);

        if (foundUserProfile == null)
        {
            return NotFound();
        }

        BlockedAccount newBlockedAccount = new BlockedAccount{
            UserProfileThatBlockedId = loggedInUser.Id,
            BlockedUserProfileId = id,
            Date = DateTime.Now 
        };

        _dbContext.BlockedAccounts.Add(newBlockedAccount);

        _dbContext.SaveChanges();

        return Created($"/api/blockedaccount/{newBlockedAccount.Id}", newBlockedAccount);
    }


}