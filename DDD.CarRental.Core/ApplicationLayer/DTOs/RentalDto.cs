using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class RentalDto
    {
        public long Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public decimal Total { get;  set; }
        public long DriverId { get; set; }
        public long CarId { get; set; }
        public int TimeInMinutes { get; set; }
    }
}
