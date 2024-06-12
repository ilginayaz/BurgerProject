
using BurgerProject.Data.Context;
using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Data.Enums;
using BurgerProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Controllers
{
    
    public class MenuController : Controller
    {

        private readonly BurgerDbContext _context;
        private UserManager<AppUser> _userManager;

        public MenuController(BurgerDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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




        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel, List<int> selectedExtras)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Error = "Sipariş vermek için giriş yapmalısınız.";
                return RedirectToAction("Index"); 
            }
            var userId = Convert.ToInt32(_userManager.GetUserId(HttpContext.User)); //sisteme login olanın id'sini verir.

        


            if (ModelState.IsValid)
            {
                // Seçilen ekstra malzemelerin listesini oluştur
                var selectedExtraList = new List<Extra>();
                if (selectedExtras != null && selectedExtras.Any())
                {
                    foreach (var extraId in selectedExtras)
                    {
                        var extra = _context.Extras.Find(extraId);
                        if (extra != null)
                        {
                            selectedExtraList.Add(extra);
                        }
                    }
                }

                // Yeni bir sipariş oluştur
                Order order = new Order
                {
                    OrderSize = orderViewModel.OrderSize,
                    MenuId = orderViewModel.MenuId,
                    Piece = orderViewModel.Piece,
                    AppUserId = userId,
                    CreatedDate = DateTime.Now,
                    Extras = selectedExtraList // Seçilen ekstra malzemeleri ekle
                };

                // Yeni siparişi kaydet
                _context.Orders.Add(order);
                _context.SaveChanges();

                
            }

            else if (!ModelState.IsValid) 
            {
                TempData["Message"] = "Sipariş vermek için gerekli yerleri doldurmalısınız.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }










    }
}




