using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BandBlend.Models;

public class Profile
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string ProfilePicture { get; set; }
    public int StateId { get; set; }
    public string City { get; set; }
    public string About { get; set; }
    public int PrimaryGenreId { get; set; }
    public int? PrimaryInstrumentId { get; set; }
    public string SpotifyLink { get; set; }
    public string FacebookLink { get; set; }
    public string InstagramLink { get; set; }
    public string TikTokLink { get; set; }
    [NotMapped]
    public bool? isSaved { get; set; }
    public UserProfile UserProfile { get; set; }
    public State State { get; set; }
    public PrimaryGenre PrimaryGenre { get; set; }
    public PrimaryInstrument PrimaryInstrument { get; set; }
    public List<ProfileSubGenre> ProfileSubGenres { get; set; }
    public List<ProfileTag> ProfileTags { get; set; }
    

}