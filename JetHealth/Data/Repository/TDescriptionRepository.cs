using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;

namespace JetHealth.Data.Repository
{
    public class TDescriptionRepository : Repository<TDescription>, ITDescriptionRepository
    {
        private readonly ApplicationDbContext _db;
        public TDescriptionRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(TDescription description)
        {
            _db.Update(description);
        }
    }
}
