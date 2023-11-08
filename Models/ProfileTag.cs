namespace BandBlend.Models;

public class ProfileTag
{
    public int Id { get; set; }
    public int TagId { get; set; }
    public int ProfileId { get; set; }
    public Tag Tag { get; set; }
    public Profile Profile { get; set; }

}