using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Post_Service.Contexts;
using Post_Service.Messaging;
using Post_Service.Models;

namespace Post_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        private IMessageService _messageService;

        public PostsController(DataContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        // GET: Posts/GetAll
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            IEnumerable<Post> posts = _context.Posts;
            return Ok(posts);
        }

        // GET: Posts/Get/5
        [HttpGet("get/{id}")]
        public IActionResult Get(int? id)
        {
            Post post = _context.Posts.First(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: Posts/Create
        [HttpPost("create")]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return Ok(post);
        }

        // PUT: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("edit/{id}")]
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
                    _context.Posts.Update(post);
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
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            _context.SaveChanges();

            return Ok();
        }
    }
}
