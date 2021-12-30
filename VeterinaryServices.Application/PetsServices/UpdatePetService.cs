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
        
        
        
    }
}