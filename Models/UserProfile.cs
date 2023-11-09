using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BandBlend.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsBand { get; set; }

    [NotMapped] // not mapped means that EF Core won't create column for this property in the db
    public string Email { get; set; }
    [NotMapped]
    public List<string> Roles { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
    // public Profile Profile { get; set; }
    public Profile Profile { get; set; }

}