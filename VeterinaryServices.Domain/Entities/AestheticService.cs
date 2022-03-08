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
            State = State == AestheticServiceState.Pending ? AestheticServiceState.InProgress : State;
        }

        public override void Output()
        {
            State = State == AestheticServiceState.InProgress ? AestheticServiceState.Completed : State;
        }

        public void Cancel()
        {
            State = State == AestheticServiceState.Pending ? AestheticServiceState.Canceled : State;
        }
    }
}