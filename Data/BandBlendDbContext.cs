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
                Email = "josh@bandblend.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
                Email = "tom@bandblend.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47",
                Email = "emily@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68",
                Email = "oliver@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79",
                Email = "Ava Martinez",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a",
                Email = "liam@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b",
                Email = "sophia@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac",
                Email = "noah@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd",
                Email = "mia@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd",
                Email = "james@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed",
                Email = "charlotte@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd",
                Email = "william@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd",
                Email = "harper@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd",
                Email = "benjamin@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id",
                Email = "evelyn@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd",
                Email = "alexander@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd",
                Email = "grace@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "00a40af9-6o6o-6o66-po6k-kk00a38j90ld",
                Email = "daniel@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md",
                Email = "madison@example.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd",
                Email = "gabriel@example.com",
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
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "00a40af9-6o6o-6o66-po6k-kk00a38j90ld"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63",
                UserId = "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd"
            }
        );
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Name = "Josh Baugh",
                Email = "josh@bandblend.comx",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
                Name = "Tom Jones",
                Email = "tom@bandblend.comx",
                AccountBanned = true,
                IsBand = false
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47",
                Name = "Emily Davis",
                Email = "emily@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68",
                Name = "Oliver Wilson",
                Email = "oliver@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79",
                Name = "Ava Martinez",
                Email = "ava@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 6,
                IdentityUserId = "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a",
                Name = "Liam Garcia",
                Email = "liam@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 7,
                IdentityUserId = "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b",
                Name = "Sophia Rodriguez",
                Email = "sophia@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 8,
                IdentityUserId = "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac",
                Name = "Noah Lopez",
                Email = "noah@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 9,
                IdentityUserId = "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd",
                Name = "Mia Gonzalez",
                Email = "mia@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 10,
                IdentityUserId = "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd",
                Name = "James Perez",
                Email = "james@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 11,
                IdentityUserId = "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed",
                Name = "Charlotte Lee",
                Email = "charlotte@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 12,
                IdentityUserId = "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd",
                Name = "William Moore",
                Email = "william@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 13,
                IdentityUserId = "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd",
                Name = "Harper Adams",
                Email = "harper@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 14,
                IdentityUserId = "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd",
                Name = "Benjamin Clark",
                Email = "benjamin@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 15,
                IdentityUserId = "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id",
                Name = "Evelyn Hill",
                Email = "evelyn@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 16,
                IdentityUserId = "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd",
                Name = "Alexander Scott",
                Email = "alexander@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 17,
                IdentityUserId = "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd",
                Name = "Grace Ward",
                Email = "grace@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 18,
                IdentityUserId = "00a40af9-6o6o-6o66-po6k-kk00a38j90ld",
                Name = "Daniel Young",
                Email = "daniel@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 19,
                IdentityUserId = "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md",
                Name = "Madison Turner",
                Email = "madison@example.com",
                AccountBanned = false,
                IsBand = false
            },
            new UserProfile
            {
                Id = 20,
                IdentityUserId = "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd",
                Name = "Gabriel Baker",
                Email = "gabriel@example.com",
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
                About = "Hey there, I'm Josh, a musician turned full-time software developer. Thanks for stopping by my Band Blend! I created this platform to make it easier for musicians and bands to connect and collaborate. Finding new members and collaborators can be tough, so I built BandBlend to help out. Have a look around, and if you've got any questions, shoot me a message here. Enjoy!",
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
                PrimaryGenreId = 1,
                PrimaryInstrumentId = 2,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 3,
                UserProfileId = 3,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 2,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 6,
                PrimaryInstrumentId = 3,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 4,
                UserProfileId = 4,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 6,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 3,
                PrimaryInstrumentId = 6,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 5,
                UserProfileId = 5,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 7,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 2,
                PrimaryInstrumentId = 2,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 6,
                UserProfileId = 6,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 7,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 2,
                PrimaryInstrumentId = 2,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 7,
                UserProfileId = 7,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 8,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 4,
                PrimaryInstrumentId = 7,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 8,
                UserProfileId = 8,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 11,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 3,
                PrimaryInstrumentId = 1,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 9,
                UserProfileId = 9,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 12,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 10,
                PrimaryInstrumentId = 9,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 10,
                UserProfileId = 10,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 19,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 5,
                PrimaryInstrumentId = 5,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 11,
                UserProfileId = 11,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 20,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 10,
                PrimaryInstrumentId = 10,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 12,
                UserProfileId = 12,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 17,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 9,
                PrimaryInstrumentId = 5,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 13,
                UserProfileId = 13,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 45,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 4,
                PrimaryInstrumentId = 8,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 14,
                UserProfileId = 14,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 49,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 3,
                PrimaryInstrumentId = 4,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 15,
                UserProfileId = 15,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 43,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 1,
                PrimaryInstrumentId = 10,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 16,
                UserProfileId = 16,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 42,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 5,
                PrimaryInstrumentId = 4,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 17,
                UserProfileId = 17,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 37,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 4,
                PrimaryInstrumentId = 8,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 18,
                UserProfileId = 18,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 27,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 6,
                PrimaryInstrumentId = 6,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 19,
                UserProfileId = 19,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 39,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 7,
                PrimaryInstrumentId = 7,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

            },
            new Profile
            {
                Id = 20,
                UserProfileId = 20,
                ProfilePicture = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80",
                City = "Somewhere",
                StateId = 26,
                About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                PrimaryGenreId = 8,
                PrimaryInstrumentId = 10,
                SpotifyLink = "https://www.facebook.com/joshbaughmusic/",
                FacebookLink = "https://www.facebook.com/joshbaughmusic/",
                InstagramLink = "https://www.instagram.com/joshbaughmusic/",
                TikTokLink = "https://www.facebook.com/joshbaughmusic/",

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

        },
        new AdditionalPicture
        {
            Id = 2,
            UserProfileId = 1,
            Url = "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80"

        },
        new AdditionalPicture
        {
            Id = 3,
            UserProfileId = 2,
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
                Body = "Post 1",
                Date = new DateTime(2023, 11, 6, 12, 2, 0)
            },
            new Post
            {
                Id = 2,
                UserProfileId = 1,
                Body = "Post 2",
                Date = new DateTime(2023, 11, 7, 12, 3, 0)
            },
            new Post
            {
                Id = 3,
                UserProfileId = 2,
                Body = "Post 3",
                Date = new DateTime(2023, 11, 8, 12, 2, 0)
            },
            new Post
            {
                Id = 4,
                UserProfileId = 1,
                Body = "Post 4",
                Date = new DateTime(2023, 11, 9, 12, 2, 0)
            },
            new Post
            {
                Id = 5,
                UserProfileId = 1,
                Body = "Post 5",
                Date = new DateTime(2023, 11, 10, 12, 2, 0)
            },
            new Post
            {
                Id = 6,
                UserProfileId = 1,
                Body = "Post 6",
                Date = new DateTime(2023, 11, 11, 12, 2, 0)
            },
            new Post
            {
                Id = 7,
                UserProfileId = 1,
                Body = "Post 7",
                Date = new DateTime(2023, 11, 12, 12, 2, 0)
            },
            new Post
            {
                Id = 8,
                UserProfileId = 1,
                Body = "Post 8",
                Date = new DateTime(2023, 11, 13, 12, 2, 0)
            },
            new Post
            {
                Id = 9,
                UserProfileId = 1,
                Body = "Post 9",
                Date = new DateTime(2023, 11, 14, 12, 2, 0)
            },
            new Post
            {
                Id = 10,
                UserProfileId = 1,
                Body = "Post 10",
                Date = new DateTime(2023, 11, 15, 12, 2, 0)
            },
            new Post
            {
                Id = 11,
                UserProfileId = 1,
                Body = "Post 11",
                Date = new DateTime(2023, 11, 16, 12, 2, 0)
            },
            new Post
            {
                Id = 12,
                UserProfileId = 1,
                Body = "Post 12",
                Date = new DateTime(2023, 11, 17, 12, 2, 0)
            },
            new Post
            {
                Id = 13,
                UserProfileId = 2,
                Body = "Post 13",
                Date = new DateTime(2023, 11, 18, 12, 2, 0)
            },
            new Post
            {
                Id = 14,
                UserProfileId = 2,
                Body = "Post 14",
                Date = new DateTime(2023, 11, 19, 12, 2, 0)
            },
            new Post
            {
                Id = 15,
                UserProfileId = 2,
                Body = "Some Post",
                Date = new DateTime(2023, 11, 20, 12, 2, 0)
            },
            new Post
            {
                Id = 16,
                UserProfileId = 3,
                Body = "That Post",
                Date = new DateTime(2023, 11, 21, 12, 2, 0)
            },
            new Post
            {
                Id = 17,
                UserProfileId = 4,
                Body = "This Post",
                Date = new DateTime(2023, 11, 22, 12, 2, 0)
            },
            new Post
            {
                Id = 18,
                UserProfileId = 5,
                Body = "A Post",
                Date = new DateTime(2023, 11, 23, 12, 2, 0)
            },
            new Post
            {
                Id = 19,
                UserProfileId = 6,
                Body = "B Post",
                Date = new DateTime(2023, 11, 24, 12, 2, 0)
            },
            new Post
            {
                Id = 20,
                UserProfileId = 7,
                Body = "C Post",
                Date = new DateTime(2023, 11, 25, 12, 2, 0)
            },
            new Post
            {
                Id = 21,
                UserProfileId = 8,
                Body = "D Post",
                Date = new DateTime(2023, 11, 26, 12, 2, 0)
            },
            new Post
            {
                Id = 22,
                UserProfileId = 9,
                Body = "E Post",
                Date = new DateTime(2023, 11, 27, 12, 2, 0)
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
            },
            new Comment
            {
                Id = 2,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 3,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 4,
                PostId = 1,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 5,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 6,
                PostId = 1,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 7,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 8,
                PostId = 1,
                UserProfileId = 9,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 9,
                PostId = 1,
                UserProfileId = 3,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 10,
                PostId = 1,
                UserProfileId = 4,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 11,
                PostId = 2,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 12,
                PostId = 2,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 13,
                PostId = 2,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 14,
                PostId = 2,
                UserProfileId = 4,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 15,
                PostId = 2,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 16,
                PostId = 2,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 17,
                PostId = 2,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 18,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 19,
                PostId = 1,
                UserProfileId = 2,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
            },
            new Comment
            {
                Id = 20,
                PostId = 2,
                UserProfileId = 1,
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Date = new DateTime(2023, 11, 6, 12, 5, 0)
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
       
        modelBuilder.Entity<FeedUserSubscription>().HasData(
       new FeedUserSubscription
       {
           Id = 1,
           UserSubbedToId = 2,
           UserThatSubbedId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedUserSubscription
       {
           Id = 2,
           UserSubbedToId = 3,
           UserThatSubbedId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedUserSubscription
       {
           Id = 3,
           UserSubbedToId = 4,
           UserThatSubbedId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedUserSubscription
       {
           Id = 4,
           UserSubbedToId = 1,
           UserThatSubbedId = 2,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedUserSubscription
       {
           Id = 5,
           UserSubbedToId = 3,
           UserThatSubbedId = 2,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       }
       );

        modelBuilder.Entity<FeedStateSubscription>().HasData(
       new FeedStateSubscription
       {
           Id = 1,
           UserProfileId = 1,
           StateId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedStateSubscription
       {
           Id = 2,
           UserProfileId = 1,
           StateId = 2,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedStateSubscription
       {
           Id = 3,
           UserProfileId = 1,
           StateId = 3,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedStateSubscription
       {
           Id = 4,
           UserProfileId = 2,
           StateId = 11,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedStateSubscription
       {
           Id = 5,
           UserProfileId = 2,
           StateId = 10,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       }
       );

        modelBuilder.Entity<FeedPrimaryGenreSubscription>().HasData(
       new FeedPrimaryGenreSubscription
       {
           Id = 1,
           UserProfileId = 1,
           PrimaryGenreId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryGenreSubscription
       {
           Id = 2,
           UserProfileId = 1,
           PrimaryGenreId = 2,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryGenreSubscription
       {
           Id = 3,
           UserProfileId = 1,
           PrimaryGenreId = 3,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryGenreSubscription
       {
           Id = 4,
           UserProfileId = 2,
           PrimaryGenreId = 11,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryGenreSubscription
       {
           Id = 5,
           UserProfileId = 2,
           PrimaryGenreId = 10,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       }
       );
       
        modelBuilder.Entity<FeedPrimaryInstrumentSubscription>().HasData(
       new FeedPrimaryInstrumentSubscription
       {
           Id = 1,
           UserProfileId = 1,
           PrimaryInstrumentId = 1,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryInstrumentSubscription
       {
           Id = 2,
           UserProfileId = 1,
           PrimaryInstrumentId = 2,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryInstrumentSubscription
       {
           Id = 3,
           UserProfileId = 1,
           PrimaryInstrumentId = 3,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryInstrumentSubscription
       {
           Id = 4,
           UserProfileId = 2,
           PrimaryInstrumentId = 7,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       },
       new FeedPrimaryInstrumentSubscription
       {
           Id = 5,
           UserProfileId = 2,
           PrimaryInstrumentId = 8,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)
       }
       );
        modelBuilder.Entity<MessageConversation>().HasData(
        new MessageConversation
        {
            Id = 1,
            UserProfileId1 = 1,
            UserProfileIdIdentityUserId1 = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserProfileId2 = 2,
            UserProfileIdIdentityUserId2 = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
            LastMessageDate = new DateTime(2023, 11, 6, 12, 6, 0)
        },
        new MessageConversation
        {
            Id = 2,
            UserProfileId1 = 1,
            UserProfileIdIdentityUserId1 = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserProfileId2 = 3,
            UserProfileIdIdentityUserId2 = "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47",
            LastMessageDate = new DateTime(2023, 11, 5, 12, 6, 0)
        },
        new MessageConversation
        {
            Id = 3,
            UserProfileId1 = 1,
            UserProfileIdIdentityUserId1 = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserProfileId2 = 4,
            UserProfileIdIdentityUserId2 = "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68",
            LastMessageDate = new DateTime(2023, 11, 4, 12, 6, 0)
        }
        );

        modelBuilder.Entity<Message>().HasData(
       new Message
       {
           Id = 1,
           MessageConversationId = 1,
           SenderId = 1,
           SenderIdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
           ReceiverId = 2,
           ReceiverIdentityUserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
           Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
           IsRead = false,
           Date = new DateTime(2023, 11, 6, 12, 6, 0)


       },
       new Message
       {
           Id = 2,
           MessageConversationId = 1,
           SenderId = 2,
           SenderIdentityUserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
           ReceiverId = 1,
           ReceiverIdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
           Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
           IsRead = false,
           Date = new DateTime(2023, 11, 6, 12, 6, 1)
       },
       new Message
       {
           Id = 3,
           MessageConversationId = 1,
           SenderId = 1,
           SenderIdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
           ReceiverId = 2,
           ReceiverIdentityUserId = "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73",
           Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
           IsRead = false,
           Date = new DateTime(2023, 11, 6, 12, 6, 2)

       },
       new Message
       {
           Id = 4,
           MessageConversationId = 2,
           SenderId = 3,
           SenderIdentityUserId = "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47",
           ReceiverId = 1,
           ReceiverIdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
           Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
           IsRead = false,
           Date = new DateTime(2023, 11, 6, 12, 6, 3)

       },
       new Message
       {
           Id = 5,
           MessageConversationId = 3,
           SenderId = 1,
           SenderIdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
           ReceiverId = 4,
           ReceiverIdentityUserId = "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68",
           Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
           IsRead = false,
           Date = new DateTime(2023, 11, 6, 12, 6, 5)

       }
       );

        //     modelBuilder.Entity<FeedCitySubscription>().HasData(
        //    new FeedCitySubscription
        //    {
        //        Id = 1,
        //        UserProfileId = 1,
        //        CityName = "Nashville",
        //        Date = new DateTime(2023, 11, 6, 12, 6, 0)
        //    },
        //    new FeedCitySubscription
        //    {
        //        Id = 2,
        //        UserProfileId = 1,
        //        CityName = "Appleton",
        //        Date = new DateTime(2023, 11, 6, 12, 6, 0)
        //    },
        //    new FeedCitySubscription
        //    {
        //        Id = 3,
        //        UserProfileId = 1,
        //        CityName = "Boulder",
        //        Date = new DateTime(2023, 11, 6, 12, 6, 0)
        //    },
        //    new FeedCitySubscription
        //    {
        //        Id = 4,
        //        UserProfileId = 2,
        //        CityName = "Franklin",
        //        Date = new DateTime(2023, 11, 6, 12, 6, 0)
        //    },
        //    new FeedCitySubscription
        //    {
        //        Id = 5,
        //        UserProfileId = 2,
        //        CityName = "Oshkosh",
        //        Date = new DateTime(2023, 11, 6, 12, 6, 0)
        //    }
        //    );


    }
}
