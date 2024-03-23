using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;

namespace JetHealth.Data.Repository
{
    public class UserRepository:Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser user)
        {
            _db.Users.Update(user);
        }
    }
}
