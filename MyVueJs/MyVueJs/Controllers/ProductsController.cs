using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVueJs.Data;
using System.Threading.Tasks;

namespace MyVueJs.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ECommerceContext _db;
        public ProductsController(ECommerceContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Slug == slug);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}