using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VeterinaryServices.Application.MedicalAppointmentsServices;
using VeterinaryServices.Application.MedicalAppointmentsServices.Requests;
using VeterinaryServices.Domain.Contracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("medical_Appointments")]
    public class MedicalAppointmentsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalAppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterMedicalAppointment(RegisterMedicalAppointmentRequest request)
        {
            var service = new RegisterMedicalAppointmentService(_unitOfWork);
            var response = await service.Execute(request);
            return Ok(response);
        }
        
    }
}