using Microsoft.AspNetCore.Mvc;

namespace BurgerProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
	}
}
