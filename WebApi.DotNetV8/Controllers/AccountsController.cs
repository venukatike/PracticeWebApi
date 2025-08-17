using Microsoft.AspNetCore.Mvc;
using WebApi.DotNetV8.Models;
using WebApi.DotNetV8.Repository.Entity;
using WebApi.DotNetV8.Repository.Interfaces;

namespace WebApi.DotNetV8.Controllers
{
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccounts _accounts;
        public AccountsController(IAccounts accounts)
        {
            _accounts = accounts;
        }
        [HttpGet("AllAccounts")]
        public async Task<List<Account>> GetAccounts()
        {
            return await _accounts.GetAccounts();
        }

        //[HttpGet("AllAccounts/{id}")]
        //public IActionResult GetAccounts(string id)
        //{
        //    if (_accounts.GetAccounts(id) == null)
        //    {
        //        return NotFound("Account Not Found");
        //    }

        //    return Ok(_accounts.GetAccounts(id));
        //}
        [HttpGet("AllAccounts/{id}")]
        public dynamic GetAccounts(string id)
        {
          

            return _accounts.GetAccounts(id);
        }
    }
}
