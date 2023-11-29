namespace BandBlend.Models;

public class FeedCitySubscription
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string CityName { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }

}