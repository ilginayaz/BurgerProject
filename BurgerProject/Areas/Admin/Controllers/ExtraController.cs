using BurgerProject.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ExtraController : Controller
	{
		private readonly BurgerDbContext _burgerDbContext;

        public ExtraController(BurgerDbContext burgerDbContext)
        {
            _burgerDbContext = burgerDbContext;
        }


        public IActionResult Index()
		{
			
			return View();
		}



	}
}
