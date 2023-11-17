namespace BandBlend.Models;

public class CommentLike
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CommentId { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public Comment Comment { get; set; }

}