using VeterinaryServices.Domain.Contracts;

namespace VeterinaryServices.Application.MedicalAppointmentsServices
{
    public class RegisterMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        
    }
}