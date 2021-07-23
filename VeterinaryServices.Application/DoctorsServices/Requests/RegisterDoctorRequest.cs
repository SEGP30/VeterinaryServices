using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Application.DoctorsServices.Requests
{
    public class RegisterDoctorRequest
    {
        public long DoctorId { get; set; }
        public string DoctorNames { get; set; }
        public string DoctorSurnames { get; set; }
        public string DoctorPhone { get; set; }
        public string DoctorAddress { get; set; }
        public Gender DoctorGender { get; set; }
        public int DoctorAge { get; set; }
    }
}