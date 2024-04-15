using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface ITImageRepository:IRepository<TImage>
    {
        public void Update(TImage image);
    }
}
