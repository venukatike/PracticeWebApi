using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DotNetV8.Data;

namespace WebApi.DotNetV8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet("GetAllFm")]
        public dynamic GetAllfm()
        {
            var results = db.accounts.ToList();
            return results;
        }

        

    }


}
