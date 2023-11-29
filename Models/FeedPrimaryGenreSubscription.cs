namespace BandBlend.Models;

public class FeedPrimaryGenreSubscription
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int PrimaryGenreId { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public PrimaryGenre PrimaryGenre { get; set; }

}