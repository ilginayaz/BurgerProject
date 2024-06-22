using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BurgerProject.Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Data.Context
{
	public class BurgerDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
	{
		public DbSet<Extra> Extras { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Order> Orders { get; set; }


		public BurgerDbContext(DbContextOptions<BurgerDbContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			

			int userId = 1;
			int roleId = 1;

			//User sees Data
			var hasher = new PasswordHasher<AppUser>();

			modelBuilder.Entity<AppUser>().HasData(
					new AppUser
					{
						Id = userId,
						Name = "Admin",
						Surname = "Admin",
						UserName = "Admin",
						NormalizedUserName = "ADMIN",
						Email = "admin@admin.com",
						EmailConfirmed = true,
						SecurityStamp= "3706511C-7374-4B05-BD82-E5708D7F6B9A",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
						PasswordHash = hasher.HashPassword(null, "12345*Abcde")
					}
				);




			//Role seed Data

			modelBuilder.Entity<IdentityRole<int>>().HasData(
					new IdentityRole<int>
					{
						Id = roleId,
						Name = "Admin",
						NormalizedName = "Admin".ToUpper()
					}
				);

			modelBuilder.Entity<IdentityRole<int>>().HasData(
					new IdentityRole<int>
					{
						Id = roleId+1,
						Name = "Customer",
						NormalizedName = "Customer".ToUpper()
					}
				);



			//UserRole seed Data

			modelBuilder.Entity<IdentityUserRole<int>>().HasData(
					new IdentityUserRole<int>
					{
						UserId = userId,
						RoleId = roleId
					}
				);



		}


	}
}
