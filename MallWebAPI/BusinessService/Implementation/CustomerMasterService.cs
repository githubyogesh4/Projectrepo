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
   public class CustomerMasterService : ICustomerMasterServices
    {
        private readonly ICustomerMasterRepository _iCustomerMasterRepository;
        private IMapper _mapper;
        public CustomerMasterService(IMapper mapper, ICustomerMasterRepository repository)
        {
            _iCustomerMasterRepository = repository;
            _mapper = mapper;
        }

        public ResultDto<long> Add(CustomerMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                IsSuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.Add(viewModel);
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
        public ResultDto<long> Update(CustomerMasterRequest viewModel)
        {
            var res = new ResultDto<long>()
            {
                IsSuccess = false,
                Data = 0,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.Update(viewModel);
            if (response == -1)
            {
                res.Errors.Add("Email Id not exists");
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
            var response = _iCustomerMasterRepository.Delete(ID);
            if (response == -1)
            {
                res.Errors.Add("Email Id not exists");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = response;
                return res;
            }
        }
        public ResultDto<CustomerMasterResponse> GetbyId(int Id)
        {
            var res = new ResultDto<CustomerMasterResponse>()
            {
                IsSuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.GetbyId(Id);
            if (response == null)
            {
                res.Errors.Add("An Error Occured");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = _mapper.Map<DBCustomerMaster, CustomerMasterResponse>(response);
                return res;
            }
        }
        public ResultDto<IEnumerable<CustomerMasterResponse>> GetAll()
        {
            var res = new ResultDto<IEnumerable<CustomerMasterResponse>>()
            {
                IsSuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.GetAll();
            if (response == null)
            {
                res.Errors.Add("An Error Occured");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = _mapper.Map<IEnumerable<DBCustomerMaster>, IEnumerable<CustomerMasterResponse>>(response);
                return res;
            }
        }
        public ResultDto<LoginResponse> Login(LoginRequest viewModel)
        {
            var res = new ResultDto<LoginResponse>()
            {
                IsSuccess = false,
                Data = null,
                Errors = new List<string>()
            };
            var response = _iCustomerMasterRepository.Login(viewModel);
            if (response == null)
            {
                res.Errors.Add("An Error Occured");
                return res;
            }
            else
            {
                res.IsSuccess = true;
                res.Data = _mapper.Map<DBLogin, LoginResponse>(response);
                return res;
            }
        }
    }
}
