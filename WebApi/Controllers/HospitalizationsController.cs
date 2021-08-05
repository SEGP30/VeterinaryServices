using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.HospitalizationsServices;
using VeterinaryServices.Application.HospitalizationsServices.Requests;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("hospitalizations")]
    public class HospitalizationsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalizationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterHospitalization(RegisterHospitalizationRequest request)
        {
            var service = new RegisterHospitalizationService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
    }
}