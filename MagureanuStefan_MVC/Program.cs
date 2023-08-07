using MagureanuStefan_MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MagureanuStefan_MVC.Repositories;
using NToastNotify;

namespace MagureanuStefan_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).
                AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            // Add services to the container.
            var clubLibraConnectionString = builder.Configuration.GetConnectionString("ClubLibraConnection") ?? throw new InvalidOperationException("Connection string 'ClubLibraConnection' not found.");
            builder.Services.AddDbContext<ClubLibraDbContext>(options =>
                options.UseSqlServer(clubLibraConnectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddControllersWithViews();

            //register repositories
            builder.Services.AddTransient<AnnouncementsRepository, AnnouncementsRepository>();
            builder.Services.AddTransient<CodeSnippetsRepository, CodeSnippetsRepository>();
            builder.Services.AddTransient<MembersRepository, MembersRepository>();
            builder.Services.AddTransient<MembershipsRepository, MembershipsRepository>();
            builder.Services.AddTransient<MembershipTypesRepository, MembershipTypesRepository>();

            builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = true,
                Timeout = 3000
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseNToastNotify();
            app.MapRazorPages();

            app.Run();
        }
    }
}