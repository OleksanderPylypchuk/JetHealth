using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface IRequestRepository:IRepository<Request>
    {
        public void Update(Request request);
    }
}
