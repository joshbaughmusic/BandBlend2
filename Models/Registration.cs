namespace BandBlend.Models;

public class Registration
{
    public bool IsBand { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public int StateId { get; set; }
    public string ProfilePicUrl { get; set; }
    public int PrimaryGenreId  { get; set; }
    public int PrimaryInstrumentId  { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Spotify { get; set; }
    public string TikTok { get; set; }
    public List<int> SubGenreIds { get; set; }
    public List<int> TagIds { get; set; }

}