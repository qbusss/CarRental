using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class DriverDto
    {
        public long Id { get; set; }
        public long LicenceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
