using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Post_Service.Contexts;
using Post_Service.Models;

namespace Post_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ApiController
    {
        private readonly PostContext _context;

        public PostsController(PostContext context)
        {
            _context = context;
        }

        // GET: Posts/GetAll
        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        // GET: Posts/Get/5
        [HttpGet("{id}")]
        public Post Get(int? id)
        {
            Post post = _context.Posts.First(x => x.Id == id);

            return post;
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(post);
        }

        // PUT: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Text,PostingDate")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Console.WriteLine("Couldn't update Post: id " + id);
                }
                return Problem("Couldn't update post");
            }
            return Ok(post);
        }

        // POST: Posts/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
