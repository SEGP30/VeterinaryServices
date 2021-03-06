using VeterinaryServices.Domain.Base;
using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Domain.Entities
{
    public class Pet : Entity<long>
    {
        public Client Owner { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public double Weigth { get; set; }
        public Gender Gender { get; set; }
        public PetSize Size { get; set; }
        public string Color { get; set; }
        public string Profile { get; set; }
    }
}