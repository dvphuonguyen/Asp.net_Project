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
    public class OrdersController : Controller
    {
        private readonly ShopDBContext _context;

        public OrdersController(ShopDBContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var shopDBContext = _context.Orders.Include(o => o.Coupon).Include(o => o.Product).Include(o => o.Shipping).Include(o => o.User);
            return View(await shopDBContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Product)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition");
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,ProductId,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OrderNumber,ProductId,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Address")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Product)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
