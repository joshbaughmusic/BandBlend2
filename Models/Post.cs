using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class Post
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string Body { get; set; }
    [NotMapped]
    public int? CommentCount { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }

}