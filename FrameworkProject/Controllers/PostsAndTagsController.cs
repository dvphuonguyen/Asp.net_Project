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
    public class PostsAndTagsController : Controller
    {
        private readonly ShopDBContext _context;

        public PostsAndTagsController(ShopDBContext context)
        {
            _context = context;
        }

        // GET: PostsAndTags
        public async Task<IActionResult> Index()
        {
            var shopDBContext = _context.Postsandtags.Include(p => p.Post).Include(p => p.Tag);
            return View(await shopDBContext.ToListAsync());
        }

        // GET: PostsAndTags/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsAndTags = await _context.Postsandtags
                .Include(p => p.Post)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postsAndTags == null)
            {
                return NotFound();
            }

            return View(postsAndTags);
        }

        // GET: PostsAndTags/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug");
            ViewData["TagId"] = new SelectList(_context.Posttags, "Id", "Slug");
            return View();
        }

        // POST: PostsAndTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostId,TagId")] PostsAndTags postsAndTags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postsAndTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postsAndTags.PostId);
            ViewData["TagId"] = new SelectList(_context.Posttags, "Id", "Slug", postsAndTags.TagId);
            return View(postsAndTags);
        }

        // GET: PostsAndTags/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsAndTags = await _context.Postsandtags.FindAsync(id);
            if (postsAndTags == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postsAndTags.PostId);
            ViewData["TagId"] = new SelectList(_context.Posttags, "Id", "Slug", postsAndTags.TagId);
            return View(postsAndTags);
        }

        // POST: PostsAndTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PostId,TagId")] PostsAndTags postsAndTags)
        {
            if (id != postsAndTags.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postsAndTags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsAndTagsExists(postsAndTags.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postsAndTags.PostId);
            ViewData["TagId"] = new SelectList(_context.Posttags, "Id", "Slug", postsAndTags.TagId);
            return View(postsAndTags);
        }

        // GET: PostsAndTags/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postsAndTags = await _context.Postsandtags
                .Include(p => p.Post)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postsAndTags == null)
            {
                return NotFound();
            }

            return View(postsAndTags);
        }

        // POST: PostsAndTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postsAndTags = await _context.Postsandtags.FindAsync(id);
            _context.Postsandtags.Remove(postsAndTags);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsAndTagsExists(long id)
        {
            return _context.Postsandtags.Any(e => e.Id == id);
        }
    }
}
