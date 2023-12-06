using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class MessageConversation
{
    public int Id { get; set; }
    public int UserProfileId1 { get; set; }
    public int UserProfileId2 { get; set; }
    public DateTime? LastMessageDate { get; set; }
    [ForeignKey("userProfileId1")]
    public UserProfile UserProfile1 { get; set; }
    [ForeignKey("userProfileId2")]
    public UserProfile UserProfile2 { get; set; }
}
