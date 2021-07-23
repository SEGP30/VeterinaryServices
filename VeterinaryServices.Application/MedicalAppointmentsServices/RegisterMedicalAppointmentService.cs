using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.MedicalAppointmentsServices.Requests;
using VeterinaryServices.Application.MedicalAppointmentsServices.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Entities;

namespace VeterinaryServices.Application.MedicalAppointmentsServices
{
    public class RegisterMedicalAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterMedicalAppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterMedicalAppointmentResponse> Execute(RegisterMedicalAppointmentRequest request)
        {
            
            var clientInDb = await _unitOfWork.ClientRepository.Find(request.OwnerId);
            if (clientInDb == null)
                return null;
            
            var clientPets = await _unitOfWork.PetRepository.FindBy(pet => pet.OwnerId == clientInDb.Id);
            var petRegistered = clientPets.FirstOrDefault(pet => pet.Name == request.PetName && pet.Gender == request.PetGender && pet.Color == request.PetColor);

            if (petRegistered == null)
                return null;
            
            var doctorInDb = await _unitOfWork.DoctorRepository.Find(request.DoctorId);
            if (doctorInDb == null)
                return null;

            var medicalAppointmentToRegister = new MedicalAppointment
            {
                Cost = request.Cost,
                CreationDate = DateTime.Now,
                Date = DateTime.Today,
                Observation = request.Observation
            };
            
            medicalAppointmentToRegister.Input(petRegistered, doctorInDb);
            
            await _unitOfWork.MedicalAppointmentRepository.Insert(medicalAppointmentToRegister);
            await _unitOfWork.Commit();

            return new RegisterMedicalAppointmentResponse
            {
                Message = "Cita médica registrada satisfactoriamente"
            };

        }
        
    }
}