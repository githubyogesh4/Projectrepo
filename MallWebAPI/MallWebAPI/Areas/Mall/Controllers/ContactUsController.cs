using System.Linq;
using BusinessEntities.Mall.RequestDto;
using BusinessService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.Mall.Controllers
{
    [Area("Mall")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    { private readonly IContactUsServices _iContactUsService;

        public ContactUsController(IContactUsServices iContactUsService)
        {
            _iContactUsService = iContactUsService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            var res = _iContactUsService.GetAll();
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Save")]
        public IActionResult Post([FromBody]ContactUsRequest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.ToArray());
            }

            var res = _iContactUsService.Add(viewModel);
            return Ok(res);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody]Value viewModel)
        {
            var res = _iContactUsService.Delete(viewModel.Id);
            return Ok(res);
        }
    }
}