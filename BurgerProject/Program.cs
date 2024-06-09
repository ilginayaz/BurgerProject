using BurgerProject.Data.Context;
using BurgerProject.Data.Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BurgerProject
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			//dbcontext baglantisi
			builder.Services.AddDbContext<BurgerDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));




			// Identity ekleme 
			builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
				.AddEntityFrameworkStores<BurgerDbContext>()
				.AddDefaultTokenProviders();



			// Cookie
			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Admin/Account/Login";    // account/login
				options.LogoutPath = "/Admin/Account/Logout";  // account/logout
			});


			// Add services to the container.
			builder.Services.AddControllersWithViews();



            // Validation ekleme
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


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



			app.UseAuthentication(); //authentication ekledim

			app.UseAuthorization();



			//rotalar
			app.MapControllerRoute(
				name: "areas",
			pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
				);


			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
