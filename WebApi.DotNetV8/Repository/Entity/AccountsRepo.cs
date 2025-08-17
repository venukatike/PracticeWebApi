using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApi.DotNetV8.Data;
using WebApi.DotNetV8.Models;
using WebApi.DotNetV8.Repository.Interfaces;

namespace WebApi.DotNetV8.Repository.Entity
{
    public class AccountsRepo : IAccounts
    {
        private readonly AppDbContext _context;
        public AccountsRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _context.accounts.ToListAsync();
        }


        public Account GetAccounts(string id)
        {
            var actu = _context.accounts.FirstOrDefault(x => x.PatNum == id);
           
            return actu; // Ensure all code paths return a value
        }

    }
}
