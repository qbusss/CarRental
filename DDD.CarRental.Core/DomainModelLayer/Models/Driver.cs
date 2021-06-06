using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Driver : Entity, IAggregateRoot
    {

        public long LicenceNumber { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal FreeMinutes { get;set; }

        protected Driver() { }

        public Driver(long driverId, long licenceNumber, string firstName, string lastName)
            : base(driverId)
        {
            if (String.IsNullOrEmpty(firstName)) throw new Exception("Driver name is null or empty");
            if (String.IsNullOrEmpty(lastName)) throw new Exception("Driver last name is null or empty");

            LicenceNumber = licenceNumber;
            FirstName = firstName;
            LastName = lastName;
            FreeMinutes = 0;

            this.AddDomainEvent(new DriverCreatedDomainEvent(this.Id, this.LicenceNumber));

        }

        public void AddFreeMinutes(IFreeMinutesPolicy policy)
        {
            this.FreeMinutes += policy.CalculateDiscount(); //?? throw new ArgumentNullException("Empty discount policy");
        }
    }

}
