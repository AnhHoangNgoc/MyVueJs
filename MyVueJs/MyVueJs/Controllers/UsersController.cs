using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVueJs.Data;
using System.Threading.Tasks;

namespace MyVueJs.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly ECommerceContext _db;

        public UsersController(ECommerceContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }
    }
}