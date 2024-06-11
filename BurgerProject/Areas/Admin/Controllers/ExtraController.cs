using BurgerProject.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerProject.Data.Entities;
using BurgerProject.Data;
using BurgerProject.Data.Entities.Concrete;
using BurgerProject.Areas.Admin.Models;

namespace BurgerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ExtraController : Controller
    {
        private readonly BurgerDbContext _burgerDbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ExtraController(BurgerDbContext burgerDbContext, IWebHostEnvironment hostingEnvironment)
        {
            _burgerDbContext = burgerDbContext;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> Index()
        {

            return View(await _burgerDbContext.Extras.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _burgerDbContext.Extras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExtraViewModel extraViewModel, Extra extra)
        {
            if (extraViewModel.LogoFile != null)
            {

                var extent = Path.GetExtension(extraViewModel.LogoFile.FileName);
                var dumyName = Guid.NewGuid().ToString();
                dumyName += extent;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dumyName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await extraViewModel.LogoFile.CopyToAsync(stream);
                }
                extra.LogoFile = dumyName;


            }
            else
            {
                extra.LogoFile = null;
            }
            if (!ModelState.IsValid)
            {
               
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage); // Hataları konsola yazdır
                    }
                }
                return View(extraViewModel);
            }
            extra.ExtraName = extraViewModel.ExtraName;
            extra.ExtraPrice = extraViewModel.ExtraPrice;
            extra.CreatedDate = DateTime.Now;
            _burgerDbContext.Add(extra);
            await _burgerDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id, ExtraViewModel extraViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _burgerDbContext.Extras.FirstOrDefaultAsync(m => m.Id == id);
            if (extra == null)
            {
                return NotFound();
            }
            extraViewModel.ExtraName = extra.ExtraName;
            extraViewModel.ExtraPrice = extra.ExtraPrice;
            extraViewModel.LogoFile = (IFormFile?)TempData["LogoFile"];
            ViewBag.LogoFile = extra.LogoFile;
            TempData["Id"] = id;
            return View(extraViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExtraViewModel extraViewModel)
        {
            var oldExtra = await _burgerDbContext.Extras.FindAsync(id);
            if (id != (int)TempData["Id"])
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(extraViewModel);
            }
            else
            {
                try
                {

                    if (oldExtra == null)
                    {
                        return NotFound();
                    }

                    if (!string.IsNullOrEmpty(oldExtra.ExtraName))
                    {
                        oldExtra.ExtraName = extraViewModel.ExtraName;
                    }

                    if (extraViewModel.ExtraPrice != null)
                    {
                        oldExtra.ExtraPrice = extraViewModel.ExtraPrice;
                    }

                    if (extraViewModel.LogoFile != null)
                    {
                        var extent = Path.GetExtension(extraViewModel.LogoFile.FileName);
                        var dumyName = Guid.NewGuid().ToString();
                        dumyName += extent;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dumyName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await extraViewModel.LogoFile.CopyToAsync(stream);
                        }
                        oldExtra.LogoFile = "wwwroot/images" + dumyName;

                    }
                    oldExtra.UpdatedDate = DateTime.Now;
                    _burgerDbContext.Update(oldExtra);
                    await _burgerDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraExists((int)TempData["Id"]))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }
        private bool ExtraExists(int id)
        {
            return _burgerDbContext.Extras.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = await _burgerDbContext.Extras
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
            var extra = await _burgerDbContext.Extras.FindAsync(id);
            if (extra != null)
            {
                _burgerDbContext.Extras.Remove(extra);
            }
            DeleteLogoFile(extra);
            await _burgerDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public void DeleteLogoFile(Extra extra)
        {
            if (extra.LogoFile != null){
                var resmiKullananBaskaVarMi = _burgerDbContext.Extras.Any(u => u.LogoFile == extra.LogoFile && u.Id != extra.Id);
                if (!resmiKullananBaskaVarMi)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    //string deleteLogo = Path.Combine(webRootPath + extra.LogoFile);

                    var deleteLogo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", extra.LogoFile);

                    System.IO.File.Delete(deleteLogo);
                }
            }
           
        }
        private bool HotelExists(int id)
        {
            return _burgerDbContext.Extras.Any(e => e.Id == id);
        }



    }
}
