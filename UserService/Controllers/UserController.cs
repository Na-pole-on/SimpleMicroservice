using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDbContext _context;

        public UserController(UserDbContext context)
            => _context = context;

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            var change = await _context.Users.FindAsync(id);
            change.Name = user.Name;
            change.Email = user.Email;
            change.Password = user.Password;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Users.FindAsync(id);
            _context.Users.Remove(delete);

            return Ok();
        }
    }
}
