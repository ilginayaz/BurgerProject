using BurgerProject.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly BurgerDbContext _burgerDbContext;
        
        public CustomerController(BurgerDbContext burgerDbContext)
        {
            _burgerDbContext = burgerDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _burgerDbContext.Users.ToListAsync());

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _burgerDbContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _burgerDbContext.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _burgerDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _burgerDbContext.Users.Remove(user);
            }
            await _burgerDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
