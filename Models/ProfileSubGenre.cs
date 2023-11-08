namespace BandBlend.Models;

public class ProfileSubGenre
{
    public int Id { get; set; }
    public int SubGenreId { get; set; }
    public int ProfileId { get; set; }
    public SubGenre SubGenre { get; set; }
    public Profile Profile { get; set; }

}