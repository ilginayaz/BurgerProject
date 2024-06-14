using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Versioning;
using System.Threading.Tasks;

namespace BurgerProject.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ICompositeViewEngine _viewEngine;
		private readonly IConfiguration _configuration;

		public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<AppUser> signInManager, ICompositeViewEngine viewEngine, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_viewEngine = viewEngine;
			_configuration = configuration;
		}


		[HttpGet]
		public IActionResult Register()
		{
			UserViewModel model = new UserViewModel();
			return View(model);
		}



		[HttpPost]
		public async Task<IActionResult> Register(UserViewModel model)
		{
			ModelState.Remove("UserId");

			if (!ModelState.IsValid)
				return View(model);

            
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Şifre ile şifre tekrarı aynı değildir.";
                return View(model);
            }


            var users = _userManager.Users.ToList();

			foreach (var item in users)
			{
				if (model.Email == item.Email)
				{
					ViewBag.ErrorMessage = $"{model.Email} adresi zaten kayıtlıdır";
					return View(model);
				}
			}

			var hasher = new PasswordHasher<AppUser>();

			AppUser user = new AppUser
			{
				Name = model.Name,
				Surname = model.Surname,
				Address = model.Address,
				Email = model.Email,
				EmailConfirmed = true,
				NormalizedEmail = model.Email.ToUpper(),
				PasswordHash = hasher.HashPassword(null, model.Password),
				UserName = model.Name,
				NormalizedUserName = model.Name.ToUpper()
			};

			IdentityResult result = await _userManager.CreateAsync(user);

			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, "Customer");


				TempData["Message"] = "Kayıt başarılı! Giriş yapabilirsiniz.";

				return RedirectToAction(nameof(Login));
			}
			else
			{
				ViewBag.ErrorMessage = "Kayıt başarısız, lütfen tüm alanları eksiksiz ve doğru bir şekilde doldurunuz";
				return View(model);
			}


		}



		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();
			return View(model);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.ErrorMessage = "Lütfen kutucukları eksiksiz ve doğru doldurunuz";
				return View(model);
			}


            AppUser user = _userManager.FindByEmailAsync(model.Email).Result;

			if (user is null)
			{
				ViewBag.ErrorMessage = "Bu e-mail ile kullanıcı bulunamamıştır";
				return View(model);
			}

			Microsoft.AspNetCore.Identity.SignInResult signInResult = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

			if (!signInResult.Succeeded)
			{
				ViewBag.ErrorMessage = "Şifre yanlıştır.";
				return View(model);
			}

			ViewBag.LoginSuccess = user.Name;

			return RedirectToAction("Index", "Home");
		}



		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}



        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit()
        {
			var userId = _userManager.GetUserId(HttpContext.User);

			var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            
            var model = new UserViewModel
            {
                UserId = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(UserViewModel model, string currentPassword, string newPassword, string confirmNewPassword)
        {
			ModelState.Remove("Password");
			ModelState.Remove("ConfirmPassword");

			ModelState.Remove("newPassword");
			ModelState.Remove("currentPassword");
			ModelState.Remove("confirmNewPassword");


            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(currentPassword) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmNewPassword))
            {
                if (newPassword != confirmNewPassword)
                {
                    ViewBag.ErrorMessage = "Yeni şifre ile şifre tekrarı aynı değil.";
                    return View(model);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Address = model.Address;
            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {

                await _signInManager.RefreshSignInAsync(user);
                TempData["SuccessMessage"] = "Kullanıcı bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


    }
}