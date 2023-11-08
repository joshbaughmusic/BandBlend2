namespace BandBlend.Models;

public class SavedProfile
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int UserProfileId { get; set; }
    public Profile Profile { get; set; }
    public UserProfile UserProfile { get; set; }

}