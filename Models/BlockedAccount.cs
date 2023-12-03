using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class BlockedAccount
{
    public int Id { get; set; }
    public int BlockedUserProfileId { get; set; }
    public int UserProfileThatBlockedId { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("BlockedUserProfileId")]
    public UserProfile BlockedUserProfile { get; set; }
    [ForeignKey("UserProfileThatBlockedId")]
    public UserProfile UserProfileThatBlocked { get; set; }

}