namespace JetHealth.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITProcedureRepository ProcedureRepository { get; }
        IUserRepository UserRepository { get; }
        ITreatmentRepository TreatmentRepository { get; }
        ITDescriptionRepository DescriptionRepository { get; }
        ITImageRepository ImageRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IRequestRepository RequestRepository { get; }
        void Save();
    }
}
