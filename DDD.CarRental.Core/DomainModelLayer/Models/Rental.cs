using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using System;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Rental: Entity, IAggregateRoot
    {
        public long RentalId { get; protected set; }
        public DateTime Started { get; protected set; }
        public DateTime Finished { get; protected set; }
        public Money Total { get; protected set; }
        private IDiscountPolicy _policy;

        protected Rental()
        { }


        public void RegisterPolicy(IDiscountPolicy policy/*, int freeMinutes*/)
        {
            this._policy = policy ?? throw new ArgumentNullException("Empty discount policy");
        }

        public void StopRental(DateTime finished, Money unitPrice)
        {
            // simple date walidation
            if (finished < Started)
                throw new Exception($"Exit date and time is earlier than enter date and time.");

            // set visit status
            this.Finished = finished;

            // calculate total
            var timeInMinutes = (this.Finished.Value - this.Started).Minutes;// - freeMinutes;
            Total = unitPrice.MultiplyBy(timeInMinutes);

            // apply discount policy and recalculate total
            if (this._policy != null)
            {
                Money discount = this._policy.CalculateDiscount(this.Total, timeInMinutes, unitPrice);
                Total = (discount > Total) ? Money.Zero : Total - discount;
            }

            this.AddDomainEvent(new VisitFishedDomainEvent(this));
        }

        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished visit");

            return (this.Finished.Value - this.Started).Minutes;
        }
    }

}
