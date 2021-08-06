using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.AestheticServices_Services;
using VeterinaryServices.Application.AestheticServices_Services.Requests;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("aesthetic_Services")]
    public class AestheticServicesController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AestheticServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterAesthethicService(RegisterAestheticServiceRequest request)
        {
            var service = new RegisterAestheticService_Service(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
    }
}