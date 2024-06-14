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
            List<double> totalPrice = FiyatHesapla(userId);
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
                    AppUserId = o.AppUserId,
                    Extras = o.Extras.ToList(),
                    MenuId = o.MenuId,
                    Menu = o.Menu
                })
                .ToList();

            for (int i = 0; i < totalPrice.Count; i++)
            {
                userOrders[i].TotalPrice = totalPrice[i];
            }
            return View(userOrders);
        }
        public IActionResult Delete(int? id) 
        { 
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();

            }
            

            return RedirectToAction(nameof(Index)); 
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Orders
                .Include(o => o.Extras)
                .Include(o => o.Menu)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderListViewModel
            {
                Id = order.Id,
                OrderSize = order.OrderSize,
                Piece = order.Piece,
                MenuName = order.Menu.MenuName,
                AppUserId = order.AppUserId,
                Extras = order.Extras.ToList(),
                MenuId = order.MenuId,
                Menu = order.Menu,
                TotalExtraPrice = order.Extras.Sum(e => e.ExtraPrice),
                MenuPrice = order.Menu.MenuPrice
            };

            viewModel.TotalPrice = CalculateTotalPrice(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(OrderListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = _context.Orders
                    .Include(o => o.Extras)
                    .Include(o => o.Menu)
                    .FirstOrDefault(o => o.Id == model.Id);

                if (order == null)
                {
                    return NotFound();
                }

                order.OrderSize = model.OrderSize;
                order.Piece = model.Piece;
                

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private double CalculateTotalPrice(OrderListViewModel order)
        {
            double totalPrice = 0;
            if (order.OrderSize == Data.Enums.OrderSize.Kucuk)
            {
                totalPrice = order.Piece * order.Menu.MenuPrice + order.TotalExtraPrice;
            }
            else if (order.OrderSize == Data.Enums.OrderSize.Orta)
            {
                double orta = 1.3;
                totalPrice = (order.Piece * order.Menu.MenuPrice) * orta + order.TotalExtraPrice;
            }
            else
            {
                double buyuk = 1.5;
                totalPrice = (order.Piece * order.Menu.MenuPrice) * buyuk + order.TotalExtraPrice;
            }
            return totalPrice;
        }

        public List<double> FiyatHesapla(int userId)
        {
            List<double> totalPriceList = new List<double>();

            List<OrderListViewModel> orderList = _context.Orders
                .Include(o => o.Extras)
                .Include(o => o.Menu)
                .Where(o => o.AppUserId == userId)
                .Select(order => new OrderListViewModel
            {
                TotalExtraPrice = order.Extras.Sum(e => e.ExtraPrice),
                OrderSize = order.OrderSize,
                Piece = order.Piece,
                Menu = order.Menu,
                MenuPrice = order.Menu.MenuPrice

            }).ToList();
            var toplamfiyat = 0;

            foreach(var order in orderList)
            {
                if(order.OrderSize == Data.Enums.OrderSize.Kucuk)
                {
                    order.TotalPrice = order.Piece * order.Menu.MenuPrice + order.TotalExtraPrice;
                }
                else if (order.OrderSize == Data.Enums.OrderSize.Orta)
                {
                    double orta = 1.3;
                    order.TotalPrice = (order.Piece * order.Menu.MenuPrice) * orta + order.TotalExtraPrice;

                }
                else
                {
                    double buyuk = 1.5;
                    order.TotalPrice = (order.Piece * order.Menu.MenuPrice) * buyuk + order.TotalExtraPrice;
                }
            };
            foreach (var order in orderList)
            {
                totalPriceList.Add(order.TotalPrice);
            }

            return totalPriceList;
        }

    }
}
