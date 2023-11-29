namespace BandBlend.Models;

public class FeedStateSubscription
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int StateId { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public State State { get; set; }

}