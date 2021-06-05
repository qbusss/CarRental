using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Policies
{
    public class StandardDiscountPolicy : IDiscountPolicy
    {
        public string Name { get; protected set; }

        public StandardDiscountPolicy()
        {
            this.Name = "Standard discount policy";
        }

        public Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice)
        {
            decimal percent = 0.01m;
            return total.MultiplyBy(percent);
        }
    }
}
