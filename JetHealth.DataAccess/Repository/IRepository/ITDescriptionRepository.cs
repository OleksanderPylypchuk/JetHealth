using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface ITDescriptionRepository:IRepository<TDescription>
    {
        public void Update(TDescription description);
    }
}
