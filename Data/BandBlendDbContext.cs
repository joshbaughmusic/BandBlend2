using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BandBlend.Models;
using Microsoft.AspNetCore.Identity;

namespace BandBlend.Data;
public class BandBlendDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<AdditionalPicture> AdditionalPictures { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<SavedProfile> SavedProfiles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageConversation> MessageConversations { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<SubGenre> SubGenres { get; set; }
    public DbSet<ProfileTag> ProfileTags { get; set; }
    public DbSet<ProfileSubGenre> ProfileSubGenres { get; set; }
    public DbSet<PrimaryGenre> PrimaryGenres { get; set; }
    public DbSet<PrimaryInstrument> PrimaryInstruments { get; set; }
    public DbSet<FeedUserSubscription> FeedUserSubscriptions { get; set; }
    public DbSet<FeedStateSubscription> FeedStateSubscriptions { get; set; }
    public DbSet<FeedPrimaryGenreSubscription> FeedPrimaryGenreSubscriptions { get; set; }
    public DbSet<FeedPrimaryInstrumentSubscription> FeedPrimaryInstrumentSubscriptions { get; set; }
    // public DbSet<FeedCitySubscription> FeedCitySubscriptions { get; set; }
    public DbSet<BlockedAccount> BlockedAccounts { get; set; }

    public BandBlendDbContext(DbContextOptions<BandBlendDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            },
            new IdentityRole
            {
                Id = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                Name = "User",
                NormalizedName = "user"
            }
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Email = "joshbaughmusic_bb@gmail.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            }
        );
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Name = "Josh Baugh",
                Email = "joshbaughmusic_bb@gmail.com",
                AccountBanned = false,
                IsBand = false
            }
            );
        modelBuilder.Entity<Profile>().HasData(
            new Profile
            {
                Id = 1,
                UserProfileId = 1,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Nashville",
                StateId = 42,
                About = "Hey there, I'm Josh, a musician turned full-time software developer. Thanks for stopping by Band Blend! I created this platform to make it easier for musicians and bands to connect and collaborate. Finding new band members and collaborators can be tough, so I built Band Blend to help out. Have a look around, and if you've got any questions, shoot me a message here. Enjoy!",
                PrimaryGenreId = 11,
                PrimaryInstrumentId = 2,
                SpotifyLink = null,
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = null,

            }
            );
        modelBuilder.Entity<State>().HasData(
            new State { Id = 1, Name = "AL" },
    new State { Id = 2, Name = "AK" },
    new State { Id = 3, Name = "AZ" },
    new State { Id = 4, Name = "AR" },
    new State { Id = 5, Name = "CA" },
    new State { Id = 6, Name = "CO" },
    new State { Id = 7, Name = "CT" },
    new State { Id = 8, Name = "DE" },
    new State { Id = 9, Name = "FL" },
    new State { Id = 10, Name = "GA" },
    new State { Id = 11, Name = "HI" },
    new State { Id = 12, Name = "ID" },
    new State { Id = 13, Name = "IL" },
    new State { Id = 14, Name = "IN" },
    new State { Id = 15, Name = "IA" },
    new State { Id = 16, Name = "KS" },
    new State { Id = 17, Name = "KY" },
    new State { Id = 18, Name = "LA" },
    new State { Id = 19, Name = "ME" },
    new State { Id = 20, Name = "MD" },
    new State { Id = 21, Name = "MA" },
    new State { Id = 22, Name = "MI" },
    new State { Id = 23, Name = "MN" },
    new State { Id = 24, Name = "MS" },
    new State { Id = 25, Name = "MO" },
    new State { Id = 26, Name = "MT" },
    new State { Id = 27, Name = "NE" },
    new State { Id = 28, Name = "NV" },
    new State { Id = 29, Name = "NH" },
    new State { Id = 30, Name = "NJ" },
    new State { Id = 31, Name = "NM" },
    new State { Id = 32, Name = "NY" },
    new State { Id = 33, Name = "NC" },
    new State { Id = 34, Name = "ND" },
    new State { Id = 35, Name = "OH" },
    new State { Id = 36, Name = "OK" },
    new State { Id = 37, Name = "OR" },
    new State { Id = 38, Name = "PA" },
    new State { Id = 39, Name = "RI" },
    new State { Id = 40, Name = "SC" },
    new State { Id = 41, Name = "SD" },
    new State { Id = 42, Name = "TN" },
    new State { Id = 43, Name = "TX" },
    new State { Id = 44, Name = "UT" },
    new State { Id = 45, Name = "VT" },
    new State { Id = 46, Name = "VA" },
    new State { Id = 47, Name = "WA" },
    new State { Id = 48, Name = "WV" },
    new State { Id = 49, Name = "WI" },
    new State { Id = 50, Name = "WY" }

                        );
        modelBuilder.Entity<AdditionalPicture>().HasData(
        new AdditionalPicture
        {
            Id = 1,
            UserProfileId = 1,
            Url = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80"

        }
        );
        modelBuilder.Entity<PrimaryInstrument>().HasData(
        new PrimaryInstrument
        {
            Id = 1,
            Name = "Acoustic Guitar"
        },
        new PrimaryInstrument
        {
            Id = 2,
            Name = "Bass"
        },
        new PrimaryInstrument
        {
            Id = 3,
            Name = "Clarinet"
        },
        new PrimaryInstrument
        {
            Id = 4,
            Name = "Drums"
        },
        new PrimaryInstrument
        {
            Id = 5,
            Name = "Electric Guitar"
        },
        new PrimaryInstrument
        {
            Id = 6,
            Name = "Flute"
        },
        new PrimaryInstrument
        {
            Id = 7,
            Name = "Harp"
        },
        new PrimaryInstrument
        {
            Id = 8,
            Name = "Keyboard"
        },
        new PrimaryInstrument
        {
            Id = 9,
            Name = "Piano"
        },
        new PrimaryInstrument
        {
            Id = 10,
            Name = "Saxophone"
        },
        new PrimaryInstrument
        {
            Id = 11,
            Name = "Steel Drum"
        },
        new PrimaryInstrument
        {
            Id = 12,
            Name = "Trombone"
        },
        new PrimaryInstrument
        {
            Id = 13,
            Name = "Trumpet"
        },
        new PrimaryInstrument
        {
            Id = 14,
            Name = "Vocals"
        },
        new PrimaryInstrument
        {
            Id = 15,
            Name = "Violin"
        },
        new PrimaryInstrument
        {
            Id = 16,
            Name = "Other"
        },
        new PrimaryInstrument
        {
            Id = 17,
            Name = "Band"
        }

        );
        modelBuilder.Entity<PrimaryGenre>().HasData(
        new PrimaryGenre
        {
            Id = 1,
            Name = "Alternative"
        },
new PrimaryGenre
{
    Id = 2,
    Name = "Blues"
},
new PrimaryGenre
{
    Id = 3,
    Name = "Classical"
},
new PrimaryGenre
{
    Id = 4,
    Name = "Country"
},
new PrimaryGenre
{
    Id = 5,
    Name = "Electronic"
},
new PrimaryGenre
{
    Id = 6,
    Name = "Folk"
},
new PrimaryGenre
{
    Id = 7,
    Name = "Hip-Hop"
},
new PrimaryGenre
{
    Id = 8,
    Name = "Indie"
},
new PrimaryGenre
{
    Id = 9,
    Name = "Jazz"
},
new PrimaryGenre
{
    Id = 10,
    Name = "Metal"
},
new PrimaryGenre
{
    Id = 11,
    Name = "Pop"
},
new PrimaryGenre
{
    Id = 12,
    Name = "Punk"
},
new PrimaryGenre
{
    Id = 13,
    Name = "R&B"
},
new PrimaryGenre
{
    Id = 14,
    Name = "Rap"
},
new PrimaryGenre
{
    Id = 15,
    Name = "Rock"
},
new PrimaryGenre
{
    Id = 16,
    Name = "Reggae"
}



        );
        modelBuilder.Entity<SubGenre>().HasData(
        new SubGenre
        {
            Id = 1,
            Name = "Acoustic Folk"
        },
new SubGenre
{
    Id = 2,
    Name = "Alternative Rock"
},
new SubGenre
{
    Id = 3,
    Name = "Bossa-Nova"
},
new SubGenre
{
    Id = 4,
    Name = "Chicago Blues"
},
new SubGenre
{
    Id = 5,
    Name = "Classic Rock"
},
new SubGenre
{
    Id = 6,
    Name = "Contemporary R&B"
},
new SubGenre
{
    Id = 7,
    Name = "Country Pop"
},
new SubGenre
{
    Id = 8,
    Name = "Dance Pop"
},
new SubGenre
{
    Id = 9,
    Name = "Deathcore"
},
new SubGenre
{
    Id = 10,
    Name = "Delta Blues"
},
new SubGenre
{
    Id = 11,
    Name = "Dream Pop"
},
new SubGenre
{
    Id = 12,
    Name = "East Coast Hip-Hop"
},
new SubGenre
{
    Id = 13,
    Name = "Fusion Jazz"
},
new SubGenre
{
    Id = 14,
    Name = "Glam Rock"
},
new SubGenre
{
    Id = 15,
    Name = "Grunge"
},
new SubGenre
{
    Id = 16,
    Name = "Hard Rock"
},
new SubGenre
{
    Id = 17,
    Name = "Hardcore Punk"
},
new SubGenre
{
    Id = 18,
    Name = "House"
},
new SubGenre
{
    Id = 19,
    Name = "Indie Folk"
},
new SubGenre
{
    Id = 20,
    Name = "Indie Pop"
},
new SubGenre
{
    Id = 21,
    Name = "Melodic Death Metal"
},
new SubGenre
{
    Id = 22,
    Name = "Metalcore"
},
new SubGenre
{
    Id = 23,
    Name = "Motown"
},
new SubGenre
{
    Id = 24,
    Name = "Neo-Soul"
},
new SubGenre
{
    Id = 25,
    Name = "Nu Metal"
},
new SubGenre
{
    Id = 26,
    Name = "Pop Punk"
},
new SubGenre
{
    Id = 27,
    Name = "Pop Rock"
},
new SubGenre
{
    Id = 28,
    Name = "Post-Punk"
},
new SubGenre
{
    Id = 29,
    Name = "Progressive Metal"
},
new SubGenre
{
    Id = 30,
    Name = "Punk"
},
new SubGenre
{
    Id = 31,
    Name = "Smooth Jazz"
},
new SubGenre
{
    Id = 32,
    Name = "Hardcore"
},
new SubGenre
{
    Id = 33,
    Name = "Synth-pop"
},
new SubGenre
{
    Id = 34,
    Name = "Techno"
},
new SubGenre
{
    Id = 35,
    Name = "Thrash Metal"
},
new SubGenre
{
    Id = 36,
    Name = "West Coast Hip-Hop"
}



        );
        modelBuilder.Entity<Tag>().HasData(

            new Tag
            {
                Id = 1,
                Name = "Beginner Friendly"
            },
new Tag
{
    Id = 2,
    Name = "Casual"
},
new Tag
{
    Id = 3,
    Name = "Collaborative"
},
new Tag
{
    Id = 4,
    Name = "Hobbyist"
},
new Tag
{
    Id = 5,
    Name = "Paying Gigs Only"
},
new Tag
{
    Id = 6,
    Name = "Passion First"
},
new Tag
{
    Id = 7,
    Name = "Professional"
},
new Tag
{
    Id = 8,
    Name = "Recording"
},
new Tag
{
    Id = 9,
    Name = "Serious"
},
new Tag
{
    Id = 10,
    Name = "Session Musician"
},
new Tag
{
    Id = 11,
    Name = "Songwriter"
},
new Tag
{
    Id = 12,
    Name = "Studio Musician"
},
new Tag
{
    Id = 13,
    Name = "Touring"
},
new Tag
{
    Id = 14,
    Name = "Versatile"
},
new Tag
{
    Id = 15,
    Name = "Weekend Warrior"
}




        );
        modelBuilder.Entity<ProfileTag>().HasData(

            new ProfileTag
            {
                Id = 1,
                ProfileId = 1,
                TagId = 1
            },
            new ProfileTag
            {
                Id = 2,
                ProfileId = 1,
                TagId = 9
            },
            new ProfileTag
            {
                Id = 3,
                ProfileId = 1,
                TagId = 14
            }
        );
        modelBuilder.Entity<ProfileSubGenre>().HasData(

            new ProfileSubGenre
            {
                Id = 1,
                ProfileId = 1,
                SubGenreId = 9
            },
            new ProfileSubGenre
            {
                Id = 2,
                ProfileId = 1,
                SubGenreId = 25
            },
            new ProfileSubGenre
            {
                Id = 3,
                ProfileId = 1,
                SubGenreId = 26
            }

        );
    }
}
