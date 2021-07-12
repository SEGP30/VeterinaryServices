using System.Threading.Tasks;
using VeterinaryServices.Application.DoctorsServices.Requests;
using VeterinaryServices.Application.DoctorsServices.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Entities;

namespace VeterinaryServices.Application.DoctorsServices
{
    public class RegisterDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterDoctorResponse> Execute(RegisterDoctorRequest request)
        {

            var doctorToRegister = new Doctor
            {
                Id = request.DoctorId,
                Names = request.DoctorNames,
                Surnames = request.DoctorSurnames,
                TelephoneNumber = request.DoctorPhone,
                Age = request.DoctorAge,
                Address = request.DoctorAddress,
                Gender = request.DoctorGender
            };

            await _unitOfWork.DoctorRepository.Insert(doctorToRegister);
            await _unitOfWork.Commit();

            return new RegisterDoctorResponse
            {
                Message = "Doctor registrado satisfactoriamente"
            };

        }
    }
}