using Microsoft.AspNetCore.Mvc;

namespace HBP.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet()]
        public ActionResult Get()
        {
            return Ok("87");

           
        }
    }
}
