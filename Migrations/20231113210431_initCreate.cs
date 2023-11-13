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
                    { "00a40af9-6o6o-6o66-po6k-kk00a38j90ld", 0, "d4afdac3-cc1f-4fb0-bbb3-e3124ec804b4", "daniel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELrbEq1kbSlCLHjU6mRp4gx/ch8oSxnHBXqOT+YgfzhpGwh6RxAMdHRaJO7nOKDHoQ==", null, false, "c4b4a898-e6b0-424c-8af3-718453fd26a9", false, null },
                    { "10a50ae9-5n5n-5n55-on5j-jj10a28i90kd", 0, "afa9ea8c-4165-40bc-a914-ed8c93a45a73", "grace@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIzOROQPH5elIOMsEFLZL3m2ebbPROC/yKl/gFtFea8E7J/fXS9CSCXVSe/928MZwg==", null, false, "5dc42427-0657-44de-9fb6-1bfc2e37ba61", false, null },
                    { "20a60ad9-4m4m-4m44-nm4i-ii20a18h90jd", 0, "054cf439-8f2d-46d5-838a-70a88c3d236a", "alexander@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJ3QEXdSzrXd2s3/5wPUGsTot5r9F+JVlRSUKECRrpZSIxq3CNKzkydYY/Tk1lh7BA==", null, false, "e1631890-515f-4979-bcb9-52e50730ce4f", false, null },
                    { "30a70ac9-3l3l-3l33-ml3h-hh30a08g90id", 0, "9580dd49-3d51-40fe-9a94-56451ad5afb7", "evelyn@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIW4xhKv3XC1FPrwR7F2ztjxdluIdZzCEiqJqAEP7fmsnYyN+uP5vTIhb9w3sF/LVw==", null, false, "d5479a46-e204-4744-847f-dd3a3a80100e", false, null },
                    { "40a80ab9-2k2k-2k22-lk2g-gg20a98f90hd", 0, "6d5ae178-c2e7-4816-bb30-449cc98ea720", "benjamin@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEqUrvTmGogQTDh8MIV8jvicoi/ocsKXlwOJrTliX/Il+7Jj75bn23TmuSrGpCsc9Q==", null, false, "5c8d769c-f164-40f8-b8e2-c74ed8522dbd", false, null },
                    { "50a90aa9-1j1j-1j11-kj1f-ff10a88e90gd", 0, "ee78810a-62da-440e-b21f-932416c333a1", "harper@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMFTE2Tb9Xp52O1dVoD6a5EpJRIWbQsg3lLENyd+bSwZ9Zs83x/wcAQd0Pef7QpZ/A==", null, false, "ff4b05ca-d4fa-4abf-90a9-dcc6361aa88d", false, null },
                    { "60a00a99-0i0i-0i00-ji0e-ee00a78d90fd", 0, "9a3ca83d-3ffd-407c-9d56-db185ecd7a7a", "william@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAENTFyVMMNO6irYpQLwp0icCCURXxC9qNhq5/ea2cosDJaZDDbz2ZOBlVNdzuOf9IJA==", null, false, "c1acb5bf-5c40-4aaa-a6b1-982570183703", false, null },
                    { "70a10a89-9h0h-9h99-ih9d-dd90a68c90ed", 0, "3b2f98b0-4d4a-4684-943a-218acc989471", "charlotte@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEHZKXtpwUAHfw/KDbGkL9wc0VUKkynYM4VCGIkKnOCUL5yhpJkj74t6qzBIYKAGRLg==", null, false, "04218fef-41a6-4f46-8368-301157d41dc9", false, null },
                    { "7f4e6f8d-71ef-4b38-9aa1-6e39e4ec7c73", 0, "c36522c2-a944-43cc-b9f9-ce10f302f95d", "tom@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEM680USdhE3U38Epj3EMEZh0ZEzvdnQzQ11WMOMdL2aekgnSM8wgCnCw1rvSqymhDQ==", null, false, "f5c48f31-df41-4176-bccf-a28ff62f553f", false, null },
                    { "80a20a79-8g0g-8egg-cg0c-cc80a58b90cd", 0, "f2f43fca-7442-4eef-b09b-1318d21f5957", "james@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEUo46P2gc/8BG8EBtunGf6BdULn6hddUzfNVDpjRMmGfExabkNtyLkqI9vJNXC/zg==", null, false, "0b8a7080-ae87-4d70-86d1-4c43068ab0d3", false, null },
                    { "90a30b69-7f9f-7dff-a6ad-bb70e49a90bd", 0, "def3245d-d8bb-4fb2-b68c-28d8403de8aa", "mia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEEC9D8/GeOBwD0ZGM2zM6Y7LTYCf5Yj2V3hYePCCamqT0Cup6bi974yhbbFY3wNawg==", null, false, "7d6a4f8b-6911-4928-a338-4cfccf618e93", false, null },
                    { "a0a30bg9-7p7p-7p77-qp7l-ll90a48k90md", 0, "af51d906-ac33-47c1-8ead-28d5f0476c11", "madison@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGXYrSQ5CPlH0/HMroABJTGMvnNyqFq4QBeMMfjywPYI0iE6t30sBxE6nAx5rdPByw==", null, false, "83833b91-b1cf-470f-a524-b6178de7b190", false, null },
                    { "a0b40c59-6e8e-6eff-f6ac-aa60f38980ac", 0, "91492c29-cca7-4a3b-94d2-de525551e7e9", "noah@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEDg6BVQk5tLexbxChsBur57LiCatCRPnxBnyZNbBvsai7134DrZEL/bd97WIcUiqaA==", null, false, "515804fd-ea5e-4630-9bea-4c4d65aa1812", false, null },
                    { "b0a20bh9-8q8q-8q88-rq8m-mm80a58l90nd", 0, "3d1821d5-3bb3-4959-bea7-982ab352508e", "gabriel@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEI26REMXuzfouaWOxWFblVMpfFqUGusQ06wTJeHVPJevSz3M7bZbueQqaA/GPQaG1A==", null, false, "ff639090-1390-4532-b99d-a2ce1a571c54", false, null },
                    { "b3f94d09-1d3f-4aaf-a6a7-ee10c0343d47", 0, "a6523f15-f054-4f9b-8176-04ba3ed0bffa", "emily@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOaWHJQfzP1Yb55SHlimPl4PtP429GrnysJf+UV28oloSaBY0KNd97Mm295iBqmRiw==", null, false, "8ba3d4be-b3cf-4eb9-8ac7-a3694cf07f75", false, null },
                    { "c1f82e19-2e4e-4cbe-b6a8-cc20d0454e68", 0, "bfa19dac-c80b-45e7-b40d-2f5aafb457ce", "oliver@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFRQ0nfPP5+YDS8ViUMyF/qhJWHmti5ZD8eHrXn+lTjJ1nfA6wzG5QRRg0IdLyJrAg==", null, false, "d16f070c-1a91-4f4d-9137-48563be64d4f", false, null },
                    { "d0e71f29-3f5f-4dbf-c6a9-dd30e0565f79", 0, "c25cbed7-a9d8-4b1d-9278-a00a4d25f8c8", "Ava Martinez", false, false, null, null, null, "AQAAAAIAAYagAAAAEBXClFa2FC4cLlPRUBmR6jawkkF0FVdu4JPgkpyW44NuuGTCEHJRvXaRfghsLdU8JQ==", null, false, "7369e3ae-7bdf-4e9e-8c63-103f5eeea4c4", false, null },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "b3e05b73-a743-4810-b64c-553032660935", "josh@bandblend.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEOkqwWYr8imNr6CLd/mx78ohmA1DVRSbwVZKTb8+8z6K2m85A5YUCK2s7N53ubBzEg==", null, false, "7391c7d4-28d1-4b75-9147-1cf080d92a4d", false, null },
                    { "e0d60e39-4f6f-4ecf-d6aa-ee40e1676f8a", 0, "910be900-b756-428c-99c3-51a244b92d88", "liam@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEOEQnZboSeiVi1XE2Vo+3etEEyHA8fVDxn8UEyli/C/W5qt9WcwQInrQ+hEMzRQORw==", null, false, "2190f5d0-60cc-4bfd-a6ec-c41756eaeae6", false, null },
                    { "f0c50d49-5f7f-5fdf-e6ab-ff50f278709b", 0, "48e219fb-52ca-41ae-94fb-171e01e3ff91", "sophia@example.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEMO6AzKbb/yeEtQ9f8VbfZ/Axy0hkrlnVlPlr6x5zt7eYOlCcG7BCvi2A1+92n6R/w==", null, false, "8d16246e-5c83-4ac4-a3df-44d7ecd858d8", false, null }
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
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", new DateTime(2023, 11, 6, 12, 5, 0, 0, DateTimeKind.Unspecified), 1, 2 });

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
