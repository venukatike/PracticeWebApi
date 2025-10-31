using HBP.api.Data;
using HBP.api.Domain_ClassLibrary.Entities;
using HBP.api.Domain_ClassLibrary.Interfaces;
using HBP.api.Models;

namespace HBP.api.Infrastucture_ClassLibrary.Repositories
{
    public class AppUserRepo : IAppUserEntity
    {
        private readonly BillingDbContext context;
        public AppUserRepo(BillingDbContext _billingDbContext)
        {
            context = _billingDbContext;
        }
        public List<AppUserEntity> GetAppUsers()
        {
            return context.AppUsers.Select(
                p => new AppUserEntity
                {
                    Username = p.Username,
                    UserId = p.UserId,
                    Email = p.Email,
                    DisplayName = p.Email,
                    PasswordHash = p.PasswordHash,
                    IsActive = p.IsActive
                }

                ).ToList();
        }
    }
}
