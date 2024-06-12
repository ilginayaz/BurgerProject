using BurgerProject.Data.Context;
using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly BurgerDbContext _context;
        private UserManager<AppUser> _userManager;

        public OrderController(BurgerDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }




        public IActionResult Index()
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User)); // Sisteme login olanın ID'sini verir.

            var userOrders = _context.Orders
                .Include(o => o.Extras)
                .Include(o => o.Menu)
                .Where(o => o.AppUserId == userId)
                .Select(o => new OrderListViewModel
                {
                    Id = o.Id,
                    OrderSize = o.OrderSize,
                    Piece = o.Piece,
                    MenuName = o.Menu.MenuName,
                    TotalPrice = ( o.Menu.MenuPrice * o.Menu.MenuPiece ) ,

                    AppUserId = o.AppUserId,
                    Extras = o.Extras.ToList(),
                    MenuId = o.MenuId,
                    Menu = o.Menu
                })
                .ToList();

            return View(userOrders);
        }


    }
}
