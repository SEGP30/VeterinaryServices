using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Domain.Entities
{
    public class AestheticService : VeterinaryService
    {
        public AestheticServiceState State { get; set; }

        public new void Input(Pet pet, Doctor doctor)
        {
            State = AestheticServiceState.Pending;
            base.Input(pet, doctor);
        }

        public void Start()
        {
            State = AestheticServiceState.InProgress;
        }

        public override void Output()
        {
            State = AestheticServiceState.Completed;
        }

        public void Cancelation()
        {
            State = AestheticServiceState.Canceled;
        }
    }
}