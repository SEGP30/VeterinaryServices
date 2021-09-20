using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.DoctorsServices;
using VeterinaryServices.Application.DoctorsServices.Requests;
using VeterinaryServices.Application.SearchServices;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route ("doctors")]
    public class DoctorsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var service = new RegisterDoctorService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchPet(string name, long id)
        {
            var service = new IndividualEntitySearchService(_unitOfWork);
            var response = await service.Execute(name, id);
            return Ok(response);
        }
    }
}