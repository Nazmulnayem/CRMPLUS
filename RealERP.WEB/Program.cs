using PTL.Data.Repository.IRepository;
using PTL.Data.Repository;
using PTL.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using PTL.Data.WorkRepo;
using PTL.Service.IRepository;
using PTL.Service.IRepository.ControlPanel;
using PTL.Data.WorkRepo.ControlPanel;

namespace RealERP.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ILogin, LoginRepository>();
            builder.Services.AddScoped<IDataAccessOLDB, DataAccessOLDB>();
            builder.Services.AddScoped<ICommon, CommonRepository>();
            builder.Services.AddScoped<ISOP, SOPRepository>();
            builder.Services.AddScoped<ICompPerm, CompPermRepository>();
            builder.Services.AddScoped<IUserPerm, UserPermRepository>();
            builder.Services.AddScoped<IComp, CompRepository>();


            // Configure AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // Add authentication services
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.LogoutPath = "/Home/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                });

            // Add session services
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            var app = builder.Build();



            //Middleware
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
            app.UseSession();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}"
            );

            app.Run();
        }
    }
}
