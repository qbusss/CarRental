using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Policies
{
    public class FreeMinutesPolicy : IFreeMinutesPolicy
    {
       public string Name { get; protected set; }

        public FreeMinutesPolicy()
        {
            this.Name = "Free minutes discount policy";
        }

        public decimal CalculateDiscount()
        {
            return 30;
        }
    }
}
