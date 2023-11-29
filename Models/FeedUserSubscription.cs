using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class FeedUserSubscription
{
    public int Id { get; set; }
    public int UserSubbedToId { get; set; }
    public int UserThatSubbedId { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey("UserSubbedToId")]
    public UserProfile UserSubbedTo { get; set; }
    [ForeignKey("UserThatSubbedId")]
    public UserProfile UserThatSubbed { get; set; }

}