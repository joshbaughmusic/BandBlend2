namespace BandBlend.Models;

public class PostLike
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int PostId { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public Post Post { get; set; }

}