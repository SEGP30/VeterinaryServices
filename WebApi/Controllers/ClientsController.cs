using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.ClientServices;
using VeterinaryServices.Application.ClientServices.Requests;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterClientRequest request)
        {
            var service = new RegisterClientService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
        
    }
}