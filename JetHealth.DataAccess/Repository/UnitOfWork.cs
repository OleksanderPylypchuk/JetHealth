using JetHealth.Data.DBContext;
using JetHealth.Data.Repository.IRepository;

namespace JetHealth.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITProcedureRepository ProcedureRepository {get;private set;}
        public IUserRepository UserRepository { get; private set; }
        public ITreatmentRepository TreatmentRepository { get; private set; }
        public ITDescriptionRepository DescriptionRepository { get; private set; }
        public ITImageRepository ImageRepository { get; private set; }
        public IReviewRepository ReviewRepository {get;private set;}
        public IRequestRepository RequestRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProcedureRepository = new TProcedureRepository(_db);
            UserRepository = new UserRepository(_db);
            TreatmentRepository = new TreatmentRepository(_db);
            DescriptionRepository=new TDescriptionRepository(_db);
            ImageRepository=new TImageRepository(_db);
            ReviewRepository=new ReviewRepository(_db);
            RequestRepository=new RequestRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
