using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.PetsServices.Requests;
using VeterinaryServices.Application.PetsServices.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Application.PetsServices
{
    public class DeletePetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeletePetResponse> Execute(DeletePetRequest request)
        {
            var petToDelete = (await _unitOfWork.PetRepository
                    .FindBy(p => p.Name == request.PetName && p.OwnerId == request.OwnerId))
                .FirstOrDefault();

            if (petToDelete == null)
                return new DeletePetResponse
                {
                    Message = "Error al intentar eliminar la Mascota"
                };

            petToDelete.State = EntityState.Inactive;
            petToDelete.UpdateTime = DateTime.Now;
            _unitOfWork.PetRepository.Update(petToDelete);
            await _unitOfWork.Commit();

            return new DeletePetResponse
            {
                Message = "La Mascota ha sido eliminada satisfactoriamente"
            };

        }
    }
}