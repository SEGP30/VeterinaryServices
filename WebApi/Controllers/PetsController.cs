using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.PetsServices;
using VeterinaryServices.Application.PetsServices.Requests;
using VeterinaryServices.Application.SearchServices;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    //TODO: IMPLEMENT API VERSION
    [ApiController]
    // [ApiVersion("1")]
    [Route("pets")]
    public class PetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Register Pet
        /// </summary>
        /// <param name="request"></param>
        /// <returns name="message"></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterPet(RegisterPetRequest request)
        {
            var service = new RegisterPetService(_unitOfWork);
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

        [HttpPut]
        public async Task<IActionResult> UpdatePet(UpdatePetRequest request)
        {
            var service = new UpdatePetService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePet(DeletePetRequest request)
        {
            var service = new DeletePetService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);

        }
    }
}