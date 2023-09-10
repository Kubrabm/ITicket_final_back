using ITicket.DAL.Data;
using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITicket.MVC.Areas.AdminPanel.Data;
using ITicket.MVC.Services;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Configuration.AddJsonFile("appsettings.json");
        var configuration = builder.Configuration;

        //Constants.ImagePath = Path.Combine(builder.Environment.WebRootPath, "img");

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Iticket.DAL"));
        });

        builder.Services.Configure<MailSetting>(configuration.GetSection("MailSettings"));

        builder.Services.AddTransient<IMailService, GmailManager>();

        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;

            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            options.Lockout.AllowedForNewUsers = true;

        }).AddEntityFrameworkStores<AppDbContext>()
          .AddDefaultTokenProviders().AddErrorDescriber<LocalizeIdentityError>();
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var dataInitializer = new DataInitializer(userManager, roleManager, dbContext);
            await dataInitializer.SeedData();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
        });

        app.Run();
    }
}

