using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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
            {
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

                return RedirectToAction("Index","Home");
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






    }
}
