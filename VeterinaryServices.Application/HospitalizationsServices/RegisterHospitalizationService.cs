using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.HospitalizationsServices.Requests;
using VeterinaryServices.Application.HospitalizationsServices.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Entities;

namespace VeterinaryServices.Application.HospitalizationsServices
{
    public class RegisterHospitalizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterHospitalizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterHospitalizationResponse> Execute(RegisterHospitalizationRequest request)
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

            var hospitalizationToRegister = new Hospitalization
            {
                Cost = request.Cost,
                CreationDate = DateTime.Now,
                Date = DateTime.Today,
                Observation = request.Observation
            };
            
            hospitalizationToRegister.Input(petRegistered, doctorInDb);

            await _unitOfWork.HospitalizationRepository.Insert(hospitalizationToRegister);
            await _unitOfWork.Commit();

            return new RegisterHospitalizationResponse
            {
                Message = "Hospitalización registrada satisfactoriamente"
            };
        }
        
    }
}