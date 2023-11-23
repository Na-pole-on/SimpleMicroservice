using Microsoft.AspNetCore.Mvc;
using ProductService.Database;
using ProductService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get() 
            => _appDbContext.Products;

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id) 
            => await _appDbContext.Products.FindAsync(id);

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            await _appDbContext.AddAsync(value);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product value)
        {
            value.Id = id;
            _appDbContext.Products.Update(value);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _appDbContext.Products.FindAsync(id);
            _appDbContext.Products.Remove(value);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
