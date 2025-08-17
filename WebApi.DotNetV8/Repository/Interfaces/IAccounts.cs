using Microsoft.AspNetCore.Mvc;
using WebApi.DotNetV8.Models;

namespace WebApi.DotNetV8.Repository.Interfaces
{
    public interface IAccounts
    {
        Task<List<Account>> GetAccounts();
        Account GetAccounts(string id);
    }
}
