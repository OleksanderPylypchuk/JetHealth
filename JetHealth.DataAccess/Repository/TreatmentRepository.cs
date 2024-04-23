using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;

namespace JetHealth.Data.Repository
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        private readonly ApplicationDbContext _db;
        public TreatmentRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public Treatment GetLast()
        {
            return _db.Treatments.OrderBy(t => t.Id).LastOrDefault();
        }

        public void Update(Treatment treatment)
        {
            _db.Update(treatment);
        }
    }
}
