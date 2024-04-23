using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface ITreatmentRepository:IRepository<Treatment>
    {
        public void Update(Treatment treatment);
        public Treatment GetLast();
    }
}
