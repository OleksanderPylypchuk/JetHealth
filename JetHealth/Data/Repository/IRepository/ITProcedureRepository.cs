using JetHealth.Models;

namespace JetHealth.Data.Repository.IRepository
{
    public interface ITProcedureRepository:IRepository<TProcedure>
    {
        public void Update(TProcedure entity);
    }
}
