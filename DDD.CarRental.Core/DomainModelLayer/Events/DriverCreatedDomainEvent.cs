using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Events
{
    public class DriverCreatedDomainEvent : DomainEvent
    {
        public long DriverId { get; private set; }
        public string RegistrationNumber { get; private set; }


        public DriverCreatedDomainEvent(long id, string registrationNumber)
        {
            this.DriverId = id;
            this.RegistrationNumber = name;
        }


    }
}
