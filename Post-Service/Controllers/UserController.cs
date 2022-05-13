using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Post_Service.Contexts;
using Post_Service.Messaging;
using Post_Service.Models;
using Post_Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            IEnumerable<User> users = _context.Users;
            return Ok(users);
        }
    }
}
