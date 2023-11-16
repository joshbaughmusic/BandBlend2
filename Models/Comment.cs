using System.ComponentModel.DataAnnotations.Schema;

namespace BandBlend.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserProfileId { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public Post Post { get; set; }


}