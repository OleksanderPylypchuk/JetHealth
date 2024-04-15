using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface IUserRepository:IRepository<ApplicationUser>
    {
        public void Update(ApplicationUser user);
    }
}
