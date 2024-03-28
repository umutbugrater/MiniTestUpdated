using BusinessLayer.Abstract;
using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using MiniTestProject.Models;

namespace MiniTestProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();


            builder.Services.ContainerDependencies();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(115);
                options.AccessDeniedPath = new PathString("/Login/AccessDenied");
                options.LoginPath = "/Login/Index";
                options.SlidingExpiration = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
         //pattern: "{area=Admin}/{controller=Dashboard}/{action=Index}/{id?}");
         pattern: "{controller=Default}/{action=Index}/{id?}");


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                var roles = new[] { "Admin",  "Member" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new AppRole
                        {
                            Name = role
                        });
                    }
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                string email = "admin@admin.com";
                string password = "Umut.2001";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new AppUser();
                    user.Name = "Umut Buðra";
                    user.Surname = "TER";
                    user.UserName = "ubt";
                    user.Email = email;
                    user.ImageUrl = "c8c59715-6fb2-465d-b26d-e36c42c38cdb.jpg";
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Admin");
                }

                string email2 = "test@hotmail.com";
                string password2 = "123456aA*";
                if (await userManager.FindByEmailAsync(email2) == null)
                {
                    var user = new AppUser();
                    user.Name = "Eren";
                    user.Surname = "UTKU";
                    user.UserName = "eu0638";
                    user.Email = email2;
                    user.ImageUrl = "Nophoto.jpg";
                    await userManager.CreateAsync(user, password2);
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }
            SeedData.EnsurePopulated(app);
            app.Run();
        }
    }
}