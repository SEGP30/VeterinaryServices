using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.AestheticServices_Services.Requests;
using VeterinaryServices.Application.AestheticServices_Services.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Entities;

namespace VeterinaryServices.Application.AestheticServices_Services
{
    public class RegisterAestheticService_Service
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAestheticService_Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterAestheticServiceResponse> Execute(RegisterAestheticServiceRequest request)
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

            var aestheticServiceToRegister = new AestheticService
            {
                Cost = request.Cost,
                CreationDate = DateTime.Now,
                Date = DateTime.Today
            };
            
            aestheticServiceToRegister.Input(petRegistered, doctorInDb);

            await _unitOfWork.AestheticServiceRepository.Insert(aestheticServiceToRegister);
            await _unitOfWork.Commit();

            return new RegisterAestheticServiceResponse
            {
                Message = "Servicio estético registrado satisfactoriamente"
            };

        }
        
    }
}