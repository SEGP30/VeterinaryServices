using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.PetsServices.Requests;
using VeterinaryServices.Application.PetsServices.Responses;
using VeterinaryServices.Domain.Contracts;

namespace VeterinaryServices.Application.PetsServices
{
    public class UpdatePetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdatePetResponse> Execute(UpdatePetRequest request)
        {
            var petToUpdate = (await _unitOfWork.PetRepository
                    .FindBy(p => p.Name == request.PetName && p.OwnerId == request.OwnerId))
                .FirstOrDefault();
            if (petToUpdate != null)
            {
                petToUpdate.Kind = request.PetKind;
                petToUpdate.Weight = request.PetWeight;
                petToUpdate.Gender = request.PetGender;
                petToUpdate.Size = request.PetSize;
                petToUpdate.Color = request.PetColor;
            }

            _unitOfWork.PetRepository.Update(petToUpdate);
            await _unitOfWork.Commit();

            return new UpdatePetResponse
            {
                Message = "Datos de Mascota actualizados satisfactoriamente"
            };
        }
    }
}