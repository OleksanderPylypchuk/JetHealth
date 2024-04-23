using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;

namespace JetHealth.Data.Repository
{
    public class TProcedureRepository : Repository<TProcedure>, ITProcedureRepository
    {
        private readonly ApplicationDbContext _db;
        public TProcedureRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(TProcedure entity)
        {
            _db.Procedures.Update(entity);
        }
    }
}
