using System.Linq;
using System.Threading.Tasks;
using VeterinaryServices.Application.SearchServices.Responses;
using VeterinaryServices.Domain.Contracts;

namespace VeterinaryServices.Application.SearchServices
{
    public class IndividualEntitySearchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndividualEntitySearchService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IndividualEntitySearchResponse> Execute(string name, long id)
        {

            var doctorInDb = await _unitOfWork.DoctorRepository.Find(id);
            if (doctorInDb != null)
            {
                return new IndividualEntitySearchResponse { Object = doctorInDb };
            }

            var petInDb = (await _unitOfWork.PetRepository
                    .FindBy(p => p.Name == name && p.OwnerId == id))
                .FirstOrDefault();
            if (petInDb != null)
            {
                return new IndividualEntitySearchResponse { Object = petInDb };
            }

            var clientInDb = await _unitOfWork.ClientRepository.Find(id);
            return clientInDb != null ? new IndividualEntitySearchResponse { Object = clientInDb } : null;
        }
    }
}