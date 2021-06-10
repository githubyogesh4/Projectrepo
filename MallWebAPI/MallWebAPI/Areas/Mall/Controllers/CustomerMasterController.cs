using System.Linq;
using BusinessEntities.Mall.RequestDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Mall.Controllers
{
    [Area("Mall")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerMasterController : ControllerBase
    {
        private readonly ICustomerMasterServices _iCustomerMasterService;

        public CustomerMasterController(ICustomerMasterServices iCustomerMasterService)
        {
            _iCustomerMasterService = iCustomerMasterService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iCustomerMasterService.GetAll();
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public IActionResult GetbyId(int Id)
        {
            var res = _iCustomerMasterService.GetbyId(Id);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post([FromBody]CustomerMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }

            var res = _iCustomerMasterService.Add(viewModel);
            return Ok(res);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update([FromBody]CustomerMasterRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }
            var res = _iCustomerMasterService.Update(viewModel);
            return Ok(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody]Value viewModel)
        {
            var res = _iCustomerMasterService.Delete(viewModel.Id);
            return Ok(res);
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login([FromBody]LoginRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }

            var res = _iCustomerMasterService.Login(viewModel);
            return Ok(res);
        }
    }
}