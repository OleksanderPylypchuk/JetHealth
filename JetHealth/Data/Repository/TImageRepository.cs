using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;

namespace JetHealth.Data.Repository
{
    public class TImageRepository : Repository<TImage>, ITImageRepository
    {
        private readonly ApplicationDbContext _db;
        public TImageRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(TImage image)
        {
            _db.Update<TImage>(image);
        }
    }
}
