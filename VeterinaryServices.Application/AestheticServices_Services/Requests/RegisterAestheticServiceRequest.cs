﻿using System;
using VeterinaryServices.Domain.Enums;

namespace VeterinaryServices.Application.AestheticServices_Services.Requests
{
    public class RegisterAestheticServiceRequest
    {
        public long OwnerId { get; set; }
        public string PetName { get; set; }
        public Gender PetGender { get; set; }
        public string PetColor { get; set; }
        public double Cost { get; set; }

        public long DoctorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Date { get; set; }
    }
}