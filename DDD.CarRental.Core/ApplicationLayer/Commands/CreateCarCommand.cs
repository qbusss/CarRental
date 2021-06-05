using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.DomainModelLayer.Models

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
   // public enum CarStatus
    //{
      //  Free = 1, // wolny
     //   Taken = 0, // zajety
    //}
    public class CreateCarCommand
    {
        public long CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal TotalDistance { get; set; }
        public CarStatus Status { get; set; }
    }
}
