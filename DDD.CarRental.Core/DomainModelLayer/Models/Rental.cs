using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using DDD.CarRental.Core.DomainModelLayer.Events;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Rental : Entity, IAggregateRoot
    {

        public DateTime Started { get; protected set; }
        public DateTime? Finished { get; protected set; }
        public Money Total { get; protected set; }
        public long CarId { get; protected set; }
        public long DriverId { get; protected set; }
        private IDiscountPolicy _policy;

        protected Rental()
        { }

        public Rental(long rentalId, long driverId, long carId, DateTime started)
    : base(rentalId)
        {
            this.Started = started;
            this.CarId = carId;
            this.DriverId = driverId;
            this.Total = Money.Zero;

            this.AddDomainEvent(new RentalStartedDomainEvent(this));
        }


        public void RegisterPolicy(IDiscountPolicy policy)
        {
            this._policy = policy;// ?? throw new ArgumentNullException("Empty discount policy");
        }

        public void StopRental(DateTime finished, Money unitPrice, decimal freeMinutes)
        {
            if (finished < Started)
                throw new Exception($"Finished date and time is earlier than startes date and time.");

            this.Finished = finished;

            var timeInMinutes = (this.Finished.Value - this.Started).Minutes - freeMinutes;
            Total = unitPrice.MultiplyBy(timeInMinutes);


            this.AddDomainEvent(new RentalFishedDomainEvent(this));
        }

        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished visit");

            return (this.Finished.Value - this.Started).Minutes;
        }
    }

}
