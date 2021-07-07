using System.Threading.Tasks;
using VeterinaryServices.Application.ClientServices.Requests;
using VeterinaryServices.Application.ClientServices.Responses;
using VeterinaryServices.Domain.Contracts;
using VeterinaryServices.Domain.Entities;

namespace VeterinaryServices.Application.ClientServices
{
    public class RegisterClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterClientResponse> Execute(RegisterClientRequest request)
        {

            var clientToRegister = new Client
            {
                Id = request.ClientId,
                Names = request.ClientNames,
                Surnames = request.ClientSurnames,
                TelephoneNumber = request.ClientPhone,
                Age = request.ClientAge,
                Address = request.ClientAddress,
                Gender = request.ClientGender
            };

            await _unitOfWork.ClientRepository.Insert(clientToRegister);
            await _unitOfWork.Commit();

            return new RegisterClientResponse
            {
                Message = "Cliente registrado satisfactoriamente"
            };

        }
        
    }
}