using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class MessageConversation
{
    public int Id { get; set; }
    public int UserProfileId1 { get; set; }
    public string UserProfileIdIdentityUserId1 { get; set; }
    public int UserProfileId2 { get; set; }
    public string UserProfileIdIdentityUserId2 { get; set; }
    public DateTime? LastMessageDate { get; set; }
    [ForeignKey("UserProfileId1")]
    public UserProfile UserProfile1 { get; set; }
    [ForeignKey("UserProfileId2")]
    public UserProfile UserProfile2 { get; set; }
}
