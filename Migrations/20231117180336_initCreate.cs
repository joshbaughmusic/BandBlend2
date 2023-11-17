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
                name: "PostLikes",
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
                    table.PrimaryKey("PK_PostLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLikes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLikes_UserProfiles_UserProfileId",
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

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CommentId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_UserProfiles_UserProfileId",
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
                    { "00a40af9-6o6o-6o66-po6k-kk00a38j90ld", 0, "6fbe524f-a404-42fa-abae-8dedc4cfe1ef", "daniel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKvFOJf5GFLAKFRSBKoSyLtcm4RZZKdnbCP8C+MPKhD4QYmceG1XHjKct2YyHJp/+w==", null, false, "cf35810e-eaca-49c9-9040-8b3197adafe0", false, null },
                    { "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd", 0, "87cb4dc9-2dfb-4d2f-8521-0ed41526c53b", "grace@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEI4KraBdRPXzeZav6BBP/Lr1iKaxOVd6Vgi3dP6sQKP1/TR5+rDluVkqVlJzmg2Z5Q==", null, false, "db9ce4b1-6d3f-4bfa-869e-74741b709729", false, null },
                    { "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd", 0, "44cbd76d-8cd2-435e-8717-e6fff92b4864", "alexander@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAENh6sIM119T5a9ZTjFpjGerjvj4R3NXV0PJyE5XFC1bUBmQn0UYe+P1McfnMOGfR7Q==", null, false, "0f9233b2-ee18-42f9-b502-225e48bd7602", false, null },
                    { "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id", 0, "0c84ba2b-836e-41cf-a040-6a934fc9cf84", "evelyn@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPC8q6MB66BYZkMIs+KSa138uEpCU/B2nBKVEwg4s1i638rdyl8j02FwE2ipuYXq6Q==", null, false, "b8640cfd-5d33-41b0-831e-1cf60beccc06", false, null },
                    { "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd", 0, "20db1f10-beb1-4163-b456-97f3f09193bc", "benjamin@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMjJ/NHPtfoLx9PBG+w4id7kL1TDNW2eE+1gQm5lTO1hGcdKZW6zdiksfly5LdQ+LQ==", null, false, "f1af1123-4e12-4c1b-aca2-2bff2cf7615d", false, null },
                    { "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd", 0, "4bf6d5d6-f2c8-4bbf-80a6-5551906dfe58", "harper@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELyhQt6iShmhQPy6i5sHUlZEQoD2bhhR4pFNnI7nijgHuVwNlS/ju9kD2d8U/Xc3sA==", null, false, "a9ba092e-5080-4118-abe8-7031ab1d9376", false, null },
                    { "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd", 0, "99dfe9fc-2c6a-4e92-9549-cacfdf5590fc", "william@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJ0NbRXSEoIyAQW8+Y9ltC1OnNEcyldWFVtrNBZThffKBB7uAb8e6V0VqQ8i9mt+rQ==", null, false, "c5503096-b72a-4c61-b305-fe6144e05362", false, null },
                    { "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed", 0, "ae6b42f9-de25-4d32-b922-590a958579a1", "charlotte@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGlaHimW4igkrq8W1mXyz/E/FvNkfsiKL6S0VD4t6rd8dsMT12bR26Y72qHAie7gNw==", null, false, "3fb0ff32-bb02-499c-98b3-5fdfeeacd15a", false, null },
                    { "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73", 0, "7980dcff-5169-446e-bcd4-aac31f71acd4", "tom@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEDSUl9WVEAY4ADlT80ly2NB93INpw+a1KTulVM5yTioqrSeUBqrwv4M0g139BtOcog==", null, false, "1aa24659-ca36-4f53-8a56-de911f48d3e1", false, null },
                    { "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd", 0, "52d3a3fd-e843-4b6e-b02a-a87eab9027c6", "james@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEDSdxH0lJgAvfbqgKVMBP6nhoa2Fo7sPsxApsvzn/FbibKF8H3QOVenKHao7lwsv3w==", null, false, "020fa282-59fd-46ef-8954-937e3a94bba8", false, null },
                    { "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd", 0, "267075b0-6234-4802-89fa-87d1ee9415c0", "mia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMC9QSoZOcyssQIK8U6gllmelO3TZ4QHhbqW3rfM4BdTHNY3SU9u9MiVwXNedXpZnA==", null, false, "c1b4a312-5a6a-4dd7-9281-286cc93d621c", false, null },
                    { "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md", 0, "d5122850-f47a-49ca-bead-6e1ad6af037f", "madison@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEnFRNbZEDx4P6XX+i4sE3TKSxK3newgkJ7LIcJxGW+7xOZuOt2FCz0AM4lcr5ZauA==", null, false, "d7c11fc9-672e-4f2a-b8b3-3e446977c1af", false, null },
                    { "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac", 0, "c5494867-a666-415f-832a-f738aca4c226", "noah@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEK0Gj5/MaJJRzTq5kTKSWDx6rZAIUP7oU3c6iJyXT1PzhjvMCY/wlkYZb8JRq9eISw==", null, false, "e54d94ea-def8-492b-b505-a9b4f2d82fd5", false, null },
                    { "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd", 0, "9b999f0a-d2eb-42c4-9917-b3bf8c03a2b4", "gabriel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMNE6Tl++SMwg2kFRXqp0en/4tVRr1eKfiNf8+m7e+8HZEYJlumMgfFh3dwMt4Y8ng==", null, false, "9cded469-c7bd-4434-b159-9e2192c798d1", false, null },
                    { "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47", 0, "b7045af1-1668-476e-a0bf-6f1d6e514a4a", "emily@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPAfmhZ1E3mfhfB3XyOEo/j+V4x8dMgL5Xl00OHtfDTxo5AxgVQ8L1dGjw74y7LKvA==", null, false, "1191dd3a-f677-403d-a744-45b89f47bade", false, null },
                    { "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68", 0, "a07ad351-b9fe-439d-927a-c6d3e9302f9d", "oliver@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGLUGnd5JMbvho8IUFDElJuaqzAs03GYR6vasmFPvDCNbwMI81HayXbs15BrtHP9SQ==", null, false, "5ef42145-be4d-407e-a2c8-9297d431ab0a", false, null },
                    { "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79", 0, "267f422a-9944-4d3d-a8f8-af9de4e706e4", "Ava Martinez", false, false, null, null, null, "AQAAAAIAAYagAAAAEDMSyv+9jj5Pt/6ZnPVgm+5W8PwDasE8rB7BlN4tTVYMqjnsuY9s7gwrfG5Pb5XMcg==", null, false, "26d8bc44-05d5-4f99-8b26-da044255235f", false, null },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "ae34fa7e-f046-4002-a536-0f35b93f3815", "josh@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEO7MMFdgwaA1hJQcC2RqJEHMUlC6EBbghYC5TsapAYO6uLC5uVnpit7m9iYoIqvRmA==", null, false, "5363876b-02e7-421b-a316-0012179f5986", false, null },
                    { "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a", 0, "c4fa2d99-4b77-422e-b602-647ae29d82e9", "liam@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEK5oow8/xTpVrGwytNf97S6nElGg93eavnPavLhtcfQqvp2qIuQrIx9rYX0Gn7FVug==", null, false, "b72c0949-43da-42cf-9668-2c8cf7379876", false, null },
                    { "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b", 0, "0fd6599f-383a-4f8e-8cbe-61c0b0819bcc", "sophia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEH1squg48KdXOJ2xc6T+D2NR29gPwpcrvmtGlFUwsN8lDwAzSupuwpPfi9+H8ibyew==", null, false, "659e0980-a686-40fc-88c6-67d5977e76f2", false, null }
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
                    { 1, "Post 1", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Post 2", new DateTime(2023, 11, 6, 12, 3, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Post 3", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Post 4", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "Post 5", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Post 6", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Post 7", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Post 8", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Post 9", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, "Post 10", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, "Post 11", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, "Post 12", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, "Post 13", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, "Post 14", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, "Post 15", new DateTime(2023, 11, 6, 12, 2, 0, 0, DateTimeKind.Unspecified), 2 }
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
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserProfileId",
                table: "CommentLikes",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserProfileId",
                table: "Comments",
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
                name: "IX_PostLikes_PostId",
                table: "PostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_UserProfileId",
                table: "PostLikes",
                column: "UserProfileId");

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
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "ProfileSubGenres");

            migrationBuilder.DropTable(
                name: "ProfileTags");

            migrationBuilder.DropTable(
                name: "SavedProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Posts");

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
