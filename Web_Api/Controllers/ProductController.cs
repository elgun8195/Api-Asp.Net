using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_Api.DATA.DAL;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(200,_context.Products.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult GetOne(int id)
        {
            Product product=_context.Products.FirstOrDefault(x => x.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            return StatusCode(200, product);
        }
        [HttpPost("")]
        public IActionResult Add(Product product)
        {
            Product newp= new Product();
            newp.Name = product.Name;
            newp.Price = product.Price;
                _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201,$"{product.Id} added!");
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
