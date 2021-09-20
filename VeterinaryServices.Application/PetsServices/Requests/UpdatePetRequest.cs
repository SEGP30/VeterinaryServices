using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Application.PetsServices.Requests
{
    public class UpdatePetRequest
    {
        public long OwnerId { get; set; }
        public string PetName { get; set; }
        public string PetKind { get; set; }
        public double PetWeight { get; set; }
        public Gender PetGender { get; set; }
        public PetSize PetSize { get; set; }
        public string PetColor { get; set; }
    }
}