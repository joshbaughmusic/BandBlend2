using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using BandBlend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSignalR();
// builder.Services.AddCors(options => 
// {
//     options.AddDefaultPolicy(builder =>
//     {
//         builder.WithOrigins("http://localhost:3000")
//         .AllowAnyHeader()
//         .AllowAnyMethod()
//         .AllowCredentials();
//     });
// });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "BandBlendLoginCookie";
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.HttpOnly = true; //The cookie cannot be accessed through JS (protects against XSS)
        options.Cookie.MaxAge = new TimeSpan(7, 0, 0, 0); // cookie expires in a week regardless of activity
        options.SlidingExpiration = true; // extend the cookie lifetime with activity up to 7 days.
        options.ExpireTimeSpan = new TimeSpan(24, 0, 0); // Cookie will expire in 24 hours without activity
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddIdentityCore<IdentityUser>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 8;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BandBlendDbContext>();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddNpgsql<BandBlendDbContext>(builder.Configuration["BandBlendDbConnectionString"]);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); 
app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();
// app.MapHub<MessageHub>("/message-hub");

app.Run();
