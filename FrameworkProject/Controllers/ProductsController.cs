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
    public class ProductsController : Controller
    {
        private readonly ShopDBContext _context;

        public ProductsController(ShopDBContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var shopDBContext = _context.Products.Include(p => p.Brand).Include(p => p.Cat).Include(p => p.ChildCat).Include(p => p.Coupon);
            return View(await shopDBContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug");
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug");
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug");
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
