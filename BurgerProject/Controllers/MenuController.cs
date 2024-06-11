
using BurgerProject.Data.Context;
using BurgerProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerProject.Controllers
{
	public class MenuController : Controller
	{

		private readonly BurgerDbContext _context;

		public MenuController(BurgerDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var menuItems = _context.Menus.ToList();
			var extraItems = _context.Extras.ToList();
			var viewModel = new MenuViewModel
			{
				Menus = menuItems,
				Extras = extraItems
			};
			return View(viewModel);
		}










	}
}
