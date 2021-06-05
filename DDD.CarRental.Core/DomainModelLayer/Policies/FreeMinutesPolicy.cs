using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Policies
{
    public class StandardDiscountPolicy : IFreeMinutesPolicy
    {
        public string Name { get; protected set; }

        public StandardDiscountPolicy()
        {
            this.Name = "Free minutes discount policy";
        }

        public int CalculateDiscount(int numOfMinutes)
        {
            decimal percent = 0.01;
            return numOfMinutes*percent;
        }
    }
}
