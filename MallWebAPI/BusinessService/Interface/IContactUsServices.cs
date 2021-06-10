using BusinessEntities.Mall.Common;
using BusinessEntities.Mall.RequestDto;
using BusinessEntities.Mall.ResponseDto;
using System.Collections.Generic;

namespace BusinessService.Interface
{
    public interface IContactUsServices
    {
        ResultDto<long> Add(ContactUsRequest viewModel);
        ResultDto<long> Delete(int ID);
        ResultDto<IEnumerable<ContactUsResponse>> GetAll();
    }
}
