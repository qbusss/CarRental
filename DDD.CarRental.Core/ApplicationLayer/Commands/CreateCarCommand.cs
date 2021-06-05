using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.DomainModelLayer.Models;


namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public enum CarStatusCommand
    {
        Available = 0,
        Reserved = 1,
        Rented = 2
    }

    public class CreateCarCommand
    {
        public long CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal TotalDistance { get; set; }
        public CarStatus Status { get; set; }
    }
}