using AutoVertical_Data;
using AutoVertical_Data.Repository;
using AutoVertical_Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using AutoVertical_Utility.EmailSender;
using System.Security.Principal;
using AutoVertical_Data.DbInitializer;
using AutoVertical_Utility.FileAcces;
using AutoVertical_Utility.Stripe;
using Stripe;
using AutoVertical_Data.DbInitializer.EntityInitiaizers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DbAccess>(option=>{
    option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<DbAccess>();
builder.Services.ConfigureApplicationCookie(option=>{
    option.AccessDeniedPath = "/Identity/Account/AccessDenied";
    option.LogoutPath= "/Identity/Account/Logout";
    option.LoginPath= "/Identity/Account/Login";
});
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IDbInitializer,DbInitializer>();
builder.Services.AddSingleton<IEmailSender,EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

SeedDatabase();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

async Task SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await dbInitializer.InitializeAsync
        (
            new CarInitializer()
        );
    }
}