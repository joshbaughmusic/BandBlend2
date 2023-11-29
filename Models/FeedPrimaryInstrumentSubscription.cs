namespace BandBlend.Models;

public class FeedPrimaryInstrumentSubscription
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int PrimaryInstrumentId { get; set; }
    public DateTime Date { get; set; }
    public UserProfile UserProfile { get; set; }
    public PrimaryInstrument PrimaryInstrument { get; set; }

}