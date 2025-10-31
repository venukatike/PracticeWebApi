using HBP.api.Domain_ClassLibrary.Entities;

namespace HBP.api.Application_ClassLibrary.Interfaces
{
    public interface IAppUserService
    {
        public List<AppUserEntity> GetAll();
    }
}
