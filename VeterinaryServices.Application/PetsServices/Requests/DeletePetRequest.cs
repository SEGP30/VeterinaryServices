namespace VeterinaryServices.Application.PetsServices.Requests
{
    public class DeletePetRequest
    {
        public long OwnerId { get; set; }
        public string PetName { get; set; }
    }
}