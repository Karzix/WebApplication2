using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryOfProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryOfProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryOfProducts
        public async Task<IActionResult> Index()
        {
              return View(await _context.CategoryOfProducts.ToListAsync());
        }

        // GET: CategoryOfProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoryOfProducts == null)
            {
                return NotFound();
            }

            var categoryOfProduct = await _context.CategoryOfProducts
                .FirstOrDefaultAsync(m => m.CategoryOfProductID == id);
            if (categoryOfProduct == null)
            {
                return NotFound();
            }

            return View(categoryOfProduct);
        }

        // GET: CategoryOfProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryOfProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryOfProductID,Description")] CategoryOfProduct categoryOfProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryOfProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryOfProduct);
        }

        // GET: CategoryOfProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoryOfProducts == null)
            {
                return NotFound();
            }

            var categoryOfProduct = await _context.CategoryOfProducts.FindAsync(id);
            if (categoryOfProduct == null)
            {
                return NotFound();
            }
            return View(categoryOfProduct);
        }

        // POST: CategoryOfProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryOfProductID,Description")] CategoryOfProduct categoryOfProduct)
        {
            if (id != categoryOfProduct.CategoryOfProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryOfProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryOfProductExists(categoryOfProduct.CategoryOfProductID))
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
            return View(categoryOfProduct);
        }

        // GET: CategoryOfProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoryOfProducts == null)
            {
                return NotFound();
            }

            var categoryOfProduct = await _context.CategoryOfProducts
                .FirstOrDefaultAsync(m => m.CategoryOfProductID == id);
            if (categoryOfProduct == null)
            {
                return NotFound();
            }

            return View(categoryOfProduct);
        }

        // POST: CategoryOfProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoryOfProducts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CategoryOfProducts'  is null.");
            }
            var categoryOfProduct = await _context.CategoryOfProducts.FindAsync(id);
            if (categoryOfProduct != null)
            {
                _context.CategoryOfProducts.Remove(categoryOfProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryOfProductExists(int id)
        {
          return _context.CategoryOfProducts.Any(e => e.CategoryOfProductID == id);
        }
    }
}
