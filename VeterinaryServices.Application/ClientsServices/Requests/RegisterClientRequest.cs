using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Application.ClientServices.Requests
{
    public class RegisterClientRequest
    {
        public long ClientId { get; set; }
        public string ClientNames { get; set; }
        public string ClientSurnames { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public Gender ClientGender { get; set; }
        public int ClientAge { get; set; }
    }
}