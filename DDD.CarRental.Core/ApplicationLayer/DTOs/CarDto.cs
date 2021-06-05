using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public enum CarStatusDto
    {
        Available = 0,
        Reserved = 1,
        Rented = 2
    }

    public class CarDto
    {
        public long CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public Distance CurrentDistance { get; set; }
        public Distance TotalDistance { get; set; }
        public CarStatusDto Status { get; set; }
    }
}
