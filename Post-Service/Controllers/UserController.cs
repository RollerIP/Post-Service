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

        // GET: api/<ValuesController>
        [HttpGet("Refresh")]
        public void RefreshUsers()
        {
            /// TODO: Button for manually refreshing this service's user table.
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
