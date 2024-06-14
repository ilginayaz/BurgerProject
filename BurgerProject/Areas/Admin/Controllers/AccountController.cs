
using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BurgerProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{

			AppUser user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{

                TempData["Message"] = "E-mail adresi geçersizdir.";
                return View(model);
			}


			var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

			if (result.Succeeded)
				return RedirectToAction("Index", "Home", new { area = "Admin" });



            TempData["Message"] = "Şifre yanlıştır.";
            return View(model);
		}


		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}

