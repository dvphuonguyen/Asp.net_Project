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
    public class PostCommentsController : Controller
    {
        private readonly ShopDBContext _context;

        public PostCommentsController(ShopDBContext context)
        {
            _context = context;
        }

        // GET: PostComments
        public async Task<IActionResult> Index()
        {
            var shopDBContext = _context.Postcomments.Include(p => p.Post).Include(p => p.User);
            return View(await shopDBContext.ToListAsync());
        }

        // GET: PostComments/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComment = await _context.Postcomments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postComment == null)
            {
                return NotFound();
            }

            return View(postComment);
        }

        // GET: PostComments/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname");
            return View();
        }

        // POST: PostComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,Comments,Status,ParentId")] PostComment postComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postComment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postComment.UserId);
            return View(postComment);
        }

        // GET: PostComments/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComment = await _context.Postcomments.FindAsync(id);
            if (postComment == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postComment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postComment.UserId);
            return View(postComment);
        }

        // POST: PostComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,PostId,Comments,Status,ParentId")] PostComment postComment)
        {
            if (id != postComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCommentExists(postComment.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postComment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postComment.UserId);
            return View(postComment);
        }

        // GET: PostComments/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postComment = await _context.Postcomments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postComment == null)
            {
                return NotFound();
            }

            return View(postComment);
        }

        // POST: PostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postComment = await _context.Postcomments.FindAsync(id);
            _context.Postcomments.Remove(postComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCommentExists(long id)
        {
            return _context.Postcomments.Any(e => e.Id == id);
        }
    }
}
