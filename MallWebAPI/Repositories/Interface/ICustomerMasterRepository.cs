using BusinessEntities.Mall.RequestDto;
using Repositories.Mall;
using System.Collections.Generic;

namespace Repositories.Interface
{
   public interface ICustomerMasterRepository
    {
        long Add(CustomerMasterRequest viewModel);
        long Update(CustomerMasterRequest viewModel);
        long Delete(int ID);
        DBCustomerMaster GetbyId(int Id);
        IEnumerable<DBCustomerMaster> GetAll();
        DBLogin Login(LoginRequest viewModel);
    }
}
