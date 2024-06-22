using BurgerProject.Data.Context;
using BurgerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BurgerProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;


        private readonly BurgerDbContext _context;

        public HomeController(ILogger<HomeController> logger, BurgerDbContext context)
        {
            _logger = logger;
            _context = context;
        }

       

        public IActionResult Index()
        {
            var menus = _context.Menus.ToList();
            var model = new MenuViewModel
            {
                Menus = menus
            };
            return View(model);
        }


        public IActionResult About()
		{
			return View();
		}



        public IActionResult Contact()
        {
            return View();
        }



       














        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
