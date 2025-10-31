using HBP.api.Application_ClassLibrary.Interfaces;
using HBP.api.Domain_ClassLibrary.Entities;
using HBP.api.Domain_ClassLibrary.Interfaces;

namespace HBP.api.Application_ClassLibrary.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserEntity _entity;
        public AppUserService(IAppUserEntity entity)
        {
            _entity = entity;
        }
        public List<AppUserEntity> GetAll()
        {
            return _entity.GetAppUsers();
        }
    }
}
