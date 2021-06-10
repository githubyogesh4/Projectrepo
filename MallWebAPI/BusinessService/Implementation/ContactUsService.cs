using AutoMapper;
using BusinessEntities.Mall.Common;
using BusinessEntities.Mall.RequestDto;
using BusinessEntities.Mall.ResponseDto;
using BusinessService.Interface;
using Repositories.Interface;
using Repositories.Mall;
using System.Collections.Generic;

namespace BusinessService.Implementation
{
    public class ContactUsService : IContactUsServices
    {
        private readonly IContactUsRepository _iContactUsRepository;
        private IMapper _mapper;
        public ContactUsService(IMapper mapper, IContactUsRepository repository)
        {
            _iContactUsRepository = repository;
            _mapper = mapper;
        }

        public ResultDto<long> Add(ContactUsRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                IsSuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iContactUsRepository.Add(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Email Id allready exists");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = response;
                return res;
            }
        }
        public ResultDto<long> Delete(int ID)
        {
            var res = new ResultDto<long>()
            {
                IsSuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iContactUsRepository.Delete(ID);
            if (response == -1)
            {
                res.Errors.Add("this contact name not exists");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = response;
                return res;
            }
        }
        public ResultDto<IEnumerable<ContactUsResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<ContactUsResponse>>()
            {
                IsSuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iContactUsRepository.GetAll();
            if (response == null)
            {
                res.Errors.Add("An Error Occured");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBContactUs>, IEnumerable<ContactUsResponse>>(response);
                return res;
            }
        }
    }
}
