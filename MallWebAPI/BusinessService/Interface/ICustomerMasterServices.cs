using BusinessEntities.Mall.Common;
using BusinessEntities.Mall.RequestDto;
using BusinessEntities.Mall.ResponseDto;
using System.Collections.Generic;

namespace BusinessService.Interface
{
    public interface ICustomerMasterServices
    {
        ResultDto<long> Add(CustomerMasterRequest viewModel);
        ResultDto<long> Update(CustomerMasterRequest viewModel);
        ResultDto<long> Delete(int ID);
        ResultDto<CustomerMasterResponse> GetbyId(int TypeId);
        ResultDto<IEnumerable<CustomerMasterResponse>> GetAll();
        ResultDto<LoginResponse> Login(LoginRequest viewModel);
    }
}
