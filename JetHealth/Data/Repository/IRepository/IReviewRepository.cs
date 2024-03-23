using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface IReviewRepository:IRepository<Review>
    {
        public void Update(Review review);
    }
}
