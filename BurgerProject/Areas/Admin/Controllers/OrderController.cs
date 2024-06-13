using BurgerProject.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {

        private readonly BurgerDbContext _burgerDbContext;
        public OrderController(BurgerDbContext burgerDbContext)
        {
                _burgerDbContext = burgerDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _burgerDbContext.Orders.ToListAsync());

        }
    }
}
