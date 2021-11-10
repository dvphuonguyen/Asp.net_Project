using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrameworkProject.Data;
using FrameworkProject.Models;

namespace FrameworkProject.Controllers
{
    public class ProductAttributesController : Controller
    {
        private readonly ShopDBContext _context;

        public ProductAttributesController(ShopDBContext context)
        {
            _context = context;
        }

        // GET: ProductAttributes
        public async Task<IActionResult> Index()
        {
            var shopDBContext = _context.Productattributes.Include(p => p.Product);
            return View(await shopDBContext.ToListAsync());
        }

        // GET: ProductAttributes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Productattributes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // GET: ProductAttributes/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition");
            return View();
        }

        // POST: ProductAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Color,Price,Stock,ProductId")] ProductAttribute productAttribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAttribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productAttribute.ProductId);
            return View(productAttribute);
        }

        // GET: ProductAttributes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Productattributes.FindAsync(id);
            if (productAttribute == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productAttribute.ProductId);
            return View(productAttribute);
        }

        // POST: ProductAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Color,Price,Stock,ProductId")] ProductAttribute productAttribute)
        {
            if (id != productAttribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAttribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAttributeExists(productAttribute.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productAttribute.ProductId);
            return View(productAttribute);
        }

        // GET: ProductAttributes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute = await _context.Productattributes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // POST: ProductAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productAttribute = await _context.Productattributes.FindAsync(id);
            _context.Productattributes.Remove(productAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductAttributeExists(long id)
        {
            return _context.Productattributes.Any(e => e.Id == id);
        }
    }
}
