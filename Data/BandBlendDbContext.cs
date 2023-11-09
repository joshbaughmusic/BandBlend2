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
    public DbSet<Like> Likes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<SubGenre> SubGenres { get; set; }
    public DbSet<ProfileTag> ProfileTags { get; set; }
    public DbSet<ProfileSubGenre> ProfileSubGenres { get; set; }
    public DbSet<PrimaryGenre> PrimaryGenres { get; set; }
    public DbSet<PrimaryInstrument> PrimaryInstruments { get; set; }

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
                Email = "josh@bandblend.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
                Email = "tom@bandblend.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73"
            }
        );
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Name = "Josh Baugh",
                Email = "josh@bandblend.comx",
                IsBand = false
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
                Name = "Tom Jones",
                Email = "tom@bandblend.comx",
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
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 1,
                PrimaryInstrumentId = 1,
                SpotifyLink = null,
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = null,

            },
            new Profile
            {
                Id = 2,
                UserProfileId = 2,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 40,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 2,
                PrimaryInstrumentId = 2,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            }
            );
        modelBuilder.Entity<State>().HasData(
            new State
            {
                Id = 1,
                Name = "Alabama"
            },
            new State
            {
                Id = 2,
                Name = "Alaska"
            },
            new State
            {
                Id = 3,
                Name = "Arizona"
            },
            new State
            {
                Id = 4,
                Name = "Arkansas"
            },
            new State
            {
                Id = 5,
                Name = "California"
            },
            new State
            {
                Id = 6,
                Name = "Colorado"
            },
            new State
            {
                Id = 7,
                Name = "Connecticut"
            },
            new State
            {
                Id = 8,
                Name = "Delaware"
            },
            new State
            {
                Id = 9,
                Name = "Florida"
            },
            new State
            {
                Id = 10,
                Name = "Georgia"
            },
            new State
            {
                Id = 11,
                Name = "Hawaii"
            },
            new State
            {
                Id = 12,
                Name = "Idaho"
            },
            new State
            {
                Id = 13,
                Name = "Illinois"
            },
            new State
            {
                Id = 14,
                Name = "Indiana"
            },
            new State
            {
                Id = 15,
                Name = "Iowa"
            },
            new State
            {
                Id = 16,
                Name = "Kansas"
            },
            new State
            {
                Id = 17,
                Name = "Kentucky"
            },
            new State
            {
                Id = 18,
                Name = "Louisiana"
            },
            new State
            {
                Id = 19,
                Name = "Maine"
            },
            new State
            {
                Id = 20,
                Name = "Maryland"
            },
            new State
            {
                Id = 21,
                Name = "Massachusetts"
            },
            new State
            {
                Id = 22,
                Name = "Michigan"
            },
            new State
            {
                Id = 23,
                Name = "Minnesota"
            },
            new State
            {
                Id = 24,
                Name = "Mississippi"
            },
            new State
            {
                Id = 25,
                Name = "Missouri"
            },
            new State
            {
                Id = 26,
                Name = "Montana"
            },
            new State
            {
                Id = 27,
                Name = "Nebraska"
            },
            new State
            {
                Id = 28,
                Name = "Nevada"
            },
            new State
            {
                Id = 29,
                Name = "New Hampshire"
            },
            new State
            {
                Id = 30,
                Name = "New Jersey"
            },
            new State
            {
                Id = 31,
                Name = "New Mexico"
            },
            new State
            {
                Id = 32,
                Name = "New York"
            },
            new State
            {
                Id = 33,
                Name = "North Carolina"
            },
            new State
            {
                Id = 34,
                Name = "North Dakota"
            },
            new State
            {
                Id = 35,
                Name = "Ohio"
            },
            new State
            {
                Id = 36,
                Name = "Oklahoma"
            },
            new State
            {
                Id = 37,
                Name = "Oregon"
            },
            new State
            {
                Id = 38,
                Name = "Pennsylvania"
            },
            new State
            {
                Id = 39,
                Name = "Rhode Island"
            },
            new State
            {
                Id = 40,
                Name = "South Carolina"
            },
            new State
            {
                Id = 41,
                Name = "South Dakota"
            },
            new State
            {
                Id = 42,
                Name = "Tennessee"
            },
            new State
            {
                Id = 43,
                Name = "Texas"
            },
            new State
            {
                Id = 44,
                Name = "Utah"
            },
            new State
            {
                Id = 45,
                Name = "Vermont"
            },
            new State
            {
                Id = 46,
                Name = "Virginia"
            },
            new State
            {
                Id = 47,
                Name = "Washington"
            },
            new State
            {
                Id = 48,
                Name = "West Virginia"
            },
            new State
            {
                Id = 49,
                Name = "Wisconsin"
            },
            new State
            {
                Id = 50,
                Name = "Wyoming"
            }

                        );
        modelBuilder.Entity<AdditionalPicture>().HasData(
        new AdditionalPicture
        {
            Id = 1,
            ProfileId = 1,
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
            Name = "Electric Guitar"
        },
        new PrimaryInstrument
        {
            Id = 3,
            Name = "Bass"
        },
        new PrimaryInstrument
        {
            Id = 4,
            Name = "Drums"
        },
        new PrimaryInstrument
        {
            Id = 5,
            Name = "Violin"
        },
        new PrimaryInstrument
        {
            Id = 6,
            Name = "Saxophone"
        },
        new PrimaryInstrument
        {
            Id = 7,
            Name = "Keyboard"
        },
        new PrimaryInstrument
        {
            Id = 8,
            Name = "Piano"
        },
        new PrimaryInstrument
        {
            Id = 9,
            Name = "Trumpet"
        },
        new PrimaryInstrument
        {
            Id = 10,
            Name = "Flute"
        },
        new PrimaryInstrument
        {
            Id = 11,
            Name = "Steel Drum"
        },
        new PrimaryInstrument
        {
            Id = 12,
            Name = "Harp"
        },
        new PrimaryInstrument
        {
            Id = 13,
            Name = "Trombone"
        },
        new PrimaryInstrument
        {
            Id = 14,
            Name = "Clarinet"
        },
        new PrimaryInstrument
        {
            Id = 15,
            Name = "Vocals"
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
            Name = "Rock"
        },
        new PrimaryGenre
        {
            Id = 2,
            Name = "Alternative"
        },
        new PrimaryGenre
        {
            Id = 3,
            Name = "Blues"
        },
        new PrimaryGenre
        {
            Id = 4,
            Name = "Classical"
        },
        new PrimaryGenre
        {
            Id = 5,
            Name = "Country"
        },
        new PrimaryGenre
        {
            Id = 6,
            Name = "Electronic"
        },
        new PrimaryGenre
        {
            Id = 7,
            Name = "Folk"
        },
        new PrimaryGenre
        {
            Id = 8,
            Name = "Hip-Hop"
        },
        new PrimaryGenre
        {
            Id = 9,
            Name = "Indie"
        },
        new PrimaryGenre
        {
            Id = 10,
            Name = "Jazz"
        },
        new PrimaryGenre
        {
            Id = 11,
            Name = "Metal"
        },
        new PrimaryGenre
        {
            Id = 12,
            Name = "Pop"
        },
        new PrimaryGenre
        {
            Id = 13,
            Name = "Punk"
        },
        new PrimaryGenre
        {
            Id = 14,
            Name = "R&B"
        },
        new PrimaryGenre
        {
            Id = 15,
            Name = "Rap"
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
            Name = "Baroque"
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
            Name = "Street Punk"
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
                Name = "Hobbyist"
            },
            new Tag
            {
                Id = 2,
                Name = "Professional"
            },
            new Tag
            {
                Id = 3,
                Name = "Weekend Warrior"
            },
            new Tag
            {
                Id = 4,
                Name = "Paying Gigs Only"
            },
            new Tag
            {
                Id = 5,
                Name = "Passion First"
            },
            new Tag
            {
                Id = 6,
                Name = "Serious"
            },
            new Tag
            {
                Id = 7,
                Name = "Casual"
            },
            new Tag
            {
                Id = 8,
                Name = "Collaborative"
            },
            new Tag
            {
                Id = 9,
                Name = "Songwriter"
            },
            new Tag
            {
                Id = 10,
                Name = "Versatile"
            },
            new Tag
            {
                Id = 11,
                Name = "Session Musician"
            },
            new Tag
            {
                Id = 12,
                Name = "Touring"
            },
            new Tag
            {
                Id = 13,
                Name = "Recording"
            },
            new Tag
            {
                Id = 14,
                Name = "Studio Musician"
            },
            new Tag
            {
                Id = 15,
                Name = "Beginner Friendly"
            }



        );
        modelBuilder.Entity<ProfileTag>().HasData(

            new ProfileTag
            {
                Id = 1,
                ProfileId = 1,
                TagId = 2
            },
            new ProfileTag
            {
                Id = 2,
                ProfileId = 1,
                TagId = 3
            },
            new ProfileTag
            {
                Id = 3,
                ProfileId = 1,
                TagId = 1
            },
            new ProfileTag
            {
                Id = 4,
                ProfileId = 2,
                TagId = 4
            },
            new ProfileTag
            {
                Id = 5,
                ProfileId = 2,
                TagId = 5
            },
            new ProfileTag
            {
                Id = 6,
                ProfileId = 2,
                TagId = 6
            }

        );
        modelBuilder.Entity<ProfileSubGenre>().HasData(

            new ProfileSubGenre
            {
                Id = 1,
                ProfileId = 1,
                SubGenreId = 2
            },
            new ProfileSubGenre
            {
                Id = 2,
                ProfileId = 1,
                SubGenreId = 3
            },
            new ProfileSubGenre
            {
                Id = 3,
                ProfileId = 1,
                SubGenreId = 1
            },
            new ProfileSubGenre
            {
                Id = 4,
                ProfileId = 2,
                SubGenreId = 4
            },
            new ProfileSubGenre
            {
                Id = 5,
                ProfileId = 2,
                SubGenreId = 5
            },
            new ProfileSubGenre
            {
                Id = 6,
                ProfileId = 2,
                SubGenreId = 6
            }

        );
        modelBuilder.Entity<Post>().HasData(

            new Post
            {
                Id = 1,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 2, 0)
            }
        );
        modelBuilder.Entity<Comment>().HasData(

            new Comment
            {
                Id = 1,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            }
        );
        modelBuilder.Entity<Like>().HasData(
            new Like
            {
                Id = 1,
                UserProfileId = 2,
                PostId = 1,
                Date = new DateTime(2023, 11, 6, 12, 18, 0)
            }
        );
        modelBuilder.Entity<SavedProfile>().HasData(
            new SavedProfile
            {
                Id = 1,
                UserProfileId = 1,
                ProfileId = 2,
            }
        );
        modelBuilder.Entity<Message>().HasData(
            new Message
            {
                Id = 1,
                SenderId = 1,
                ReceiverId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)

            },
            new Message
            {
                Id = 2,
                SenderId = 2,
                ReceiverId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 6, 0)

            }
        );



    }
}
