using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BandBlend2.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalPictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryInstruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsBand = table.Column<bool>(type: "boolean", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    About = table.Column<string>(type: "text", nullable: true),
                    PrimaryGenreId = table.Column<int>(type: "integer", nullable: false),
                    PrimaryInstrumentId = table.Column<int>(type: "integer", nullable: true),
                    SpotifyLink = table.Column<string>(type: "text", nullable: true),
                    FacebookLink = table.Column<string>(type: "text", nullable: true),
                    InstagramLink = table.Column<string>(type: "text", nullable: true),
                    TikTokLink = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_PrimaryGenres_PrimaryGenreId",
                        column: x => x.PrimaryGenreId,
                        principalTable: "PrimaryGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_PrimaryInstruments_PrimaryInstrumentId",
                        column: x => x.PrimaryInstrumentId,
                        principalTable: "PrimaryInstruments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileSubGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubGenreId = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileSubGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileSubGenres_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileSubGenres_SubGenres_SubGenreId",
                        column: x => x.SubGenreId,
                        principalTable: "SubGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileTags_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedProfiles_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdditionalPictures",
                columns: new[] { "Id", "Url", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", 1 },
                    { 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", 1 },
                    { 3, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", null, "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00a40af9-6o6o-6o66-po6k-kk00a38j90ld", 0, "97abace2-bdc5-4957-8c19-5e406b1b5fdf", "daniel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEC5ckWkZlUY5TBAzqIx3P4OSaaH1ZQY5PCXxy63JkDhzp+KCYg89LAlbOMsZVLpWaA==", null, false, "41d68f29-1003-4e3d-915e-a347db02f4de", false, null },
                    { "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd", 0, "ad1c3973-f5a1-4dbc-8e15-08835a272c62", "grace@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEiTHP0jTVtLoEc7VsRr9r2nycjf2NEucTkx2QRKgVw4WGtKTKBrLoKUApRjpwczXg==", null, false, "28823e0a-27a6-4fa5-9bbc-317437b21419", false, null },
                    { "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd", 0, "39d3b813-07fc-4d4f-ac29-91ac1bf51896", "alexander@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAECxVKxArp9X85kmDcS3kjJLKXGabVzF/YObHTOxH3+iaogXzB/yA7z7DD6QDTyxuKg==", null, false, "4191ab18-3fe9-4d58-919b-e298bac6aece", false, null },
                    { "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id", 0, "0d3562ce-bd6a-44df-ad7d-55c1802cc5f3", "evelyn@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEL2+V835zzjNfsubXiSk0kvpG/oDhpb3xANI4lN1DVpIhicrzPSQCMHBJ70hPIS3cg==", null, false, "e146e11a-98a3-4a8f-ad57-f9f47c6168e8", false, null },
                    { "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd", 0, "d34db4ba-0411-469e-90b5-1873067e7a81", "benjamin@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELwqv+cT9IzSGgBEOJFVgQqXYUWdzJEVIRL8aJml5UBF3FoiutOJYlC6rxXALqMGog==", null, false, "5a3eaa58-4668-4efe-90c1-8dbed0370c36", false, null },
                    { "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd", 0, "32143522-c3dc-4d35-9bbf-8dc03f3e45ef", "harper@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEAlJV4MOqloh0v/QjPHM8VCr71tcEqolQRZKmgRNBA0PjikO386husESYyTp4+cvrg==", null, false, "0ca97981-17e6-4a1a-954b-de1951472431", false, null },
                    { "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd", 0, "c1c0a5e4-4c37-4b72-9ccf-93e4dad34f8f", "william@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJbQ6sUwFnEznEgzkRd8vcdFcnA01BcpgQxJGTZwe1khIgYzrkk55sO2CJp++R31VQ==", null, false, "6f83d369-e688-4f91-9fff-b160eb795afc", false, null },
                    { "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed", 0, "ad55b5c7-8a0d-4696-a9a7-19be9d04fe4a", "charlotte@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELh8H6FHWNnnFQbgmWoJ5TLntcnntXYHad60l5jqEyvshRBbiJ6zKcqP51iRItn6Yg==", null, false, "92f4d8e3-90f6-4c14-9c31-2940df762790", false, null },
                    { "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73", 0, "abbec9f3-93f3-4fce-a6ce-25ebedd7cf5f", "tom@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEFC98v3VLZ8bzh/Nb0klxB/KgbmemNM1jw79GCFEvvy7M1E0fgipkptjgatqRg0m3Q==", null, false, "d84df5a7-14c3-4aa7-b4f8-3a04480541fd", false, null },
                    { "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd", 0, "daeafe0f-2b9e-4e87-ae8e-005af6f1dc59", "james@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKQ/fBZB7JiCbMtXlqK7l8aNvSfNmA5Vdw1huvc7re87l4M6SxWtCxaHw/nkQ8hxDQ==", null, false, "58abd877-cc07-4085-97a8-79386ab92b3b", false, null },
                    { "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd", 0, "edfc1846-b188-475b-9c23-b0628d0d2692", "mia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOuJsfDcTRr/9rUbmJj/TG7JJCPlW6Xluc4kUuZ/jxQwz4jhE0bm8mSAbKI0f54YXw==", null, false, "14970f9e-532c-4bbe-9a46-cf5c604ec242", false, null },
                    { "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md", 0, "9dfd1096-f9b8-48bc-a8c9-368db2a10bfc", "madison@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBgpxfVt3oaak2EGtUcPGoAHJ9PFyrE8IXfBgLyahme8w+YcNqJbtKm+eGCTp9jTJg==", null, false, "3e2b40fe-e106-4983-aa83-109c14b6fc5c", false, null },
                    { "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac", 0, "59d50965-376c-403c-80ea-67244e56caeb", "noah@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKq5gdIQkvDkwuSC1bdE+4YfeJwsqC07L++8fucZWPzm+FJQm5CYCG/xT2Ew1TuyRA==", null, false, "df1e52d4-6f87-4c22-af55-ecb300c6f500", false, null },
                    { "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd", 0, "dc1cfab0-00f6-4de2-aad6-3a6657bcb41c", "gabriel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEMYSXoaPhPQ6OHiSn2LlFAcpiGxnbz1mPErxht/ejWA+LDD3VqZ/Dfao376xOP6IQ==", null, false, "d0224f3f-3afe-4952-9e98-45f9972d21d5", false, null },
                    { "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47", 0, "6bab457e-c8f5-44f2-b80e-44369cb2a362", "emily@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKyOIy8GjS0Fl7d+S9JMtSzyMB6ljuO6PAZAi8MbqlcVxpw/OX5PEntSv1WsFuJpkQ==", null, false, "7ecc74f9-fd0e-4e03-9640-c3edfecf99fd", false, null },
                    { "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68", 0, "70ce834b-e8b7-470d-af30-da9ea181a279", "oliver@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOJI/SqvqGNAROlmCAjbpH9QFHScusav5Qu1psTFF3YkWaXhSMTY44be6QF2P70G8A==", null, false, "8f5fd5a2-d75a-4ed2-ac2d-7b12d1dc1ef6", false, null },
                    { "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79", 0, "7b83ee18-de83-49a2-a507-e34544e93a88", "Ava Martinez", false, false, null, null, null, "AQAAAAIAAYagAAAAEN4R48N1pS9wK40LSDUyOJ6Mi9EQWezw5s6IXwNaHMuNbu+6knr9SncrgMhDB2C4hQ==", null, false, "87e85745-53f7-4cac-a440-58159545ab1b", false, null },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "81e16de8-0d1d-44ef-a912-b9e5b1fb1d09", "josh@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEEWJ4lnIf4C6qJFthzS8JaWDHmK6xjXf+oJNhkfSmdlr20s3RWRtP1TEoq7PsFjJiw==", null, false, "53f5fbf7-a2a0-4398-acac-486d9366696b", false, null },
                    { "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a", 0, "420b27c8-4fb5-4ddb-a0c8-8f81740abf7a", "liam@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEA7s75POubuSOFaWFwDLEbG5zTtXOkkt/RiidjFDUFK8xA3kzmpJJsmH8KH4LpIb4A==", null, false, "078010ed-17fa-4fa0-8b1d-a7bb0015f981", false, null },
                    { "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b", 0, "5003947e-5da8-42e1-8dd0-3362fc47e51e", "sophia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAENOV18acqll05jJtyVdZOx1+a0Yfs3p4y+BY2z4aCTUaSw49yKV3B946d0YHR+yXjA==", null, false, "43dd1545-2bde-484d-8573-d7ee85a03775", false, null }
                });

            migrationBuilder.InsertData(
                table: "PrimaryGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Alternative" },
                    { 3, "Blues" },
                    { 4, "Classical" },
                    { 5, "Country" },
                    { 6, "Electronic" },
                    { 7, "Folk" },
                    { 8, "Hip-Hop" },
                    { 9, "Indie" },
                    { 10, "Jazz" },
                    { 11, "Metal" },
                    { 12, "Pop" },
                    { 13, "Punk" },
                    { 14, "R&B" },
                    { 15, "Rap" },
                    { 16, "Reggae" }
                });

            migrationBuilder.InsertData(
                table: "PrimaryInstruments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Acoustic Guitar" },
                    { 2, "Electric Guitar" },
                    { 3, "Bass" },
                    { 4, "Drums" },
                    { 5, "Violin" },
                    { 6, "Saxophone" },
                    { 7, "Keyboard" },
                    { 8, "Piano" },
                    { 9, "Trumpet" },
                    { 10, "Flute" },
                    { 11, "Steel Drum" },
                    { 12, "Harp" },
                    { 13, "Trombone" },
                    { 14, "Clarinet" },
                    { 15, "Vocals" },
                    { 16, "Other" },
                    { 17, "Band" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AL" },
                    { 2, "AK" },
                    { 3, "AZ" },
                    { 4, "AR" },
                    { 5, "CA" },
                    { 6, "CO" },
                    { 7, "CT" },
                    { 8, "DE" },
                    { 9, "FL" },
                    { 10, "GA" },
                    { 11, "HI" },
                    { 12, "ID" },
                    { 13, "IL" },
                    { 14, "IN" },
                    { 15, "IA" },
                    { 16, "KS" },
                    { 17, "KY" },
                    { 18, "LA" },
                    { 19, "ME" },
                    { 20, "MD" },
                    { 21, "MA" },
                    { 22, "MI" },
                    { 23, "MN" },
                    { 24, "MS" },
                    { 25, "MO" },
                    { 26, "MT" },
                    { 27, "NE" },
                    { 28, "NV" },
                    { 29, "NH" },
                    { 30, "NJ" },
                    { 31, "NM" },
                    { 32, "NY" },
                    { 33, "NC" },
                    { 34, "ND" },
                    { 35, "OH" },
                    { 36, "OK" },
                    { 37, "OR" },
                    { 38, "PA" },
                    { 39, "RI" },
                    { 40, "SC" },
                    { 41, "SD" },
                    { 42, "TN" },
                    { 43, "TX" },
                    { 44, "UT" },
                    { 45, "VT" },
                    { 46, "VA" },
                    { 47, "WA" },
                    { 48, "WV" },
                    { 49, "WI" },
                    { 50, "WY" }
                });

            migrationBuilder.InsertData(
                table: "SubGenres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Acoustic Folk" },
                    { 2, "Alternative Rock" },
                    { 3, "Baroque" },
                    { 4, "Chicago Blues" },
                    { 5, "Classic Rock" },
                    { 6, "Contemporary R&B" },
                    { 7, "Country Pop" },
                    { 8, "Dance Pop" },
                    { 9, "Deathcore" },
                    { 10, "Delta Blues" },
                    { 11, "Dream Pop" },
                    { 12, "East Coast Hip-Hop" },
                    { 13, "Fusion Jazz" },
                    { 14, "Glam Rock" },
                    { 15, "Grunge" },
                    { 16, "Hard Rock" },
                    { 17, "Hardcore Punk" },
                    { 18, "House" },
                    { 19, "Indie Folk" },
                    { 20, "Indie Pop" },
                    { 21, "Melodic Death Metal" },
                    { 22, "Metalcore" },
                    { 23, "Motown" },
                    { 24, "Neo-Soul" },
                    { 25, "Nu Metal" },
                    { 26, "Pop Punk" },
                    { 27, "Pop Rock" },
                    { 28, "Post-Punk" },
                    { 29, "Progressive Metal" },
                    { 30, "Punk" },
                    { 31, "Smooth Jazz" },
                    { 32, "Street Punk" },
                    { 33, "Synth-pop" },
                    { 34, "Techno" },
                    { 35, "Thrash Metal" },
                    { 36, "West Coast Hip-Hop" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hobbyist" },
                    { 2, "Professional" },
                    { 3, "Weekend Warrior" },
                    { 4, "Paying Gigs Only" },
                    { 5, "Passion First" },
                    { 6, "Serious" },
                    { 7, "Casual" },
                    { 8, "Collaborative" },
                    { 9, "Songwriter" },
                    { 10, "Versatile" },
                    { 11, "Session Musician" },
                    { 12, "Touring" },
                    { 13, "Recording" },
                    { 14, "Studio Musician" },
                    { 15, "Beginner Friendly" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "00a40af9-6o6o-6o66-po6k-kk00a38j90ld" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a" },
                    { "d13f78a0-531c-4ae4-92d6-e1ea9fdd7d63", "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "IdentityUserId", "IsBand", "Name" },
                values: new object[,]
                {
                    { 1, "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", false, "Josh Baugh" },
                    { 2, "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73", false, "Tom Jones" },
                    { 3, "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47", false, "Emily Davis" },
                    { 4, "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68", false, "Oliver Wilson" },
                    { 5, "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79", false, "Ava Martinez" },
                    { 6, "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a", false, "Liam Garcia" },
                    { 7, "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b", false, "Sophia Rodriguez" },
                    { 8, "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac", false, "Noah Lopez" },
                    { 9, "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd", false, "Mia Gonzalez" },
                    { 10, "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd", false, "James Perez" },
                    { 11, "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed", false, "Charlotte Lee" },
                    { 12, "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd", false, "William Moore" },
                    { 13, "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd", false, "Harper Adams" },
                    { 14, "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd", false, "Benjamin Clark" },
                    { 15, "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id", false, "Evelyn Hill" },
                    { 16, "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd", false, "Alexander Scott" },
                    { 17, "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd", false, "Grace Ward" },
                    { 18, "00a40af9-6o6o-6o66-po6k-kk00a38j90ld", false, "Daniel Young" },
                    { 19, "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md", false, "Madison Turner" },
                    { 20, "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd", false, "Gabriel Baker" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Date", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 3, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "About", "City", "FacebookLink", "InstagramLink", "PrimaryGenreId", "PrimaryInstrumentId", "ProfilePicture", "SpotifyLink", "StateId", "TikTokLink", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Nashville", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 1, 1, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", null, 42, null, 1 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 2 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 3 },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 4 },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 5 },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 6 },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 7 },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 8 },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 9 },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 10 },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 11 },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 12 },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 13 },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 14 },
                    { 15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 15 },
                    { 16, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 16 },
                    { 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 17 },
                    { 18, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 18 },
                    { 19, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 19 },
                    { 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Somewhere", "https://www.facebook.com/joshbaughmusic/", "https://www.instagram.com/joshbaughmusic/", 2, 2, "https://images.unsplash.com/photo-1516122276289-c28ffbaf888c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1287&q=80", "https://www.facebook.com/joshbaughmusic/", 40, "https://www.facebook.com/joshbaughmusic/", 20 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "Date", "PostId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 16, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 18, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 19, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "Date", "PostId", "UserProfileId" },
                values: new object[] { 1, new DateTime(2023, 11, 6, 12, 18, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Body", "Date", "IsRead", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), false, 2, 1 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 6, 0, 0, DateTimeKind.Unspecified), false, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProfileSubGenres",
                columns: new[] { "Id", "ProfileId", "SubGenreId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 1 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProfileTags",
                columns: new[] { "Id", "ProfileId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 1 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "SavedProfiles",
                columns: new[] { "Id", "ProfileId", "UserProfileId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserProfileId",
                table: "Comments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserProfileId",
                table: "Likes",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserProfileId",
                table: "Posts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PrimaryGenreId",
                table: "Profiles",
                column: "PrimaryGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PrimaryInstrumentId",
                table: "Profiles",
                column: "PrimaryInstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StateId",
                table: "Profiles",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserProfileId",
                table: "Profiles",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSubGenres_ProfileId",
                table: "ProfileSubGenres",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileSubGenres_SubGenreId",
                table: "ProfileSubGenres",
                column: "SubGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTags_ProfileId",
                table: "ProfileTags",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTags_TagId",
                table: "ProfileTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedProfiles_ProfileId",
                table: "SavedProfiles",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedProfiles_UserProfileId",
                table: "SavedProfiles",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalPictures");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProfileSubGenres");

            migrationBuilder.DropTable(
                name: "ProfileTags");

            migrationBuilder.DropTable(
                name: "SavedProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "PrimaryGenres");

            migrationBuilder.DropTable(
                name: "PrimaryInstruments");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
