using BurgerProject.Areas.Admin.Models;
using BurgerProject.Data.Context;
using BurgerProject.Data.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        private readonly BurgerDbContext _dbContext;

        public MenuController(BurgerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Menus.ToListAsync());
        }

        // GET: 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _dbContext.Menus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: 
        public IActionResult Create()
        {
            MenuViewModel viewModel = new MenuViewModel();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.ImageFile is not null)
                {
                    var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.ImageFile.FileName);
                    model.ImageName = model.ImageFile.FileName;

                    var akisOrtami = new FileStream(konum, FileMode.Create);


                    model.ImageFile.CopyTo(akisOrtami);

                }

                Menu menu = new Menu();
                menu.MenuName = model.MenuName;
                menu.MenuPrice = model.MenuPrice;
                menu.ImageName = model.ImageName;
                _dbContext.Menus.Add(menu);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET:
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _dbContext.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }


        [HttpPost]
        public IActionResult Edit(MenuViewModel model, int id)
        {
            var oldMenu = _dbContext.Menus.FirstOrDefault(m => m.Id == id);
            if (oldMenu == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (model.ImageFile is null)
                {
                    model.ImageName = Request.Form["ExistingImageName"];
                }
                else
                {
                    if (model.ImageFile.Name != model.ImageName)
                    {
                        model.ImageName = model.ImageFile.FileName;
                        var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.ImageFile.FileName);
                        using (var akisOrtami = new FileStream(konum, FileMode.Create))
                        {

                            model.ImageFile.CopyTo(akisOrtami);
                        }
                    }
                }

                oldMenu.MenuName = model.MenuName;
                oldMenu.MenuPrice = model.MenuPrice;
                oldMenu.ImageName = model.ImageName;
                oldMenu.UpdatedDate = DateTime.Now;
                _dbContext.Update(oldMenu);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _dbContext.Menus.FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _dbContext.Menus.FindAsync(id);
            if (menu != null)
            {
                _dbContext.Menus.Remove(menu);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _dbContext.Menus.Any(e => e.Id == id);
        }
    }
}
