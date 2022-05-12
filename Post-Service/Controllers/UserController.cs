using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Post_Service.Contexts;
using Post_Service.Messaging;
using Post_Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Post_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _context;
        private IMessageService _messageService;
        public UserController(IMessageService messageService, DataContext context)
        {
            _context = context;
            _messageService = messageService;

            _messageService.Subscribe("UserUpdate", OnUserUpdate);
        }

        private void OnUserUpdate(NatsMessage message)
        {
            User user = JsonConvert.DeserializeObject<User>(message.content);

            _context.Update(user);
            _context.SaveChanges();
        }

        // GET: api/<ValuesController>
        [HttpGet("Refresh")]
        public void RefreshUsers()
        {
            /// TODO: Button for manually refreshing this service's user table.
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
