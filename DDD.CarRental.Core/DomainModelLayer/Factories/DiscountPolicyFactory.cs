using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Policies;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class DiscountPolicyFactory
    {
        public IDiscountPolicy Create(Driver driver)
        {
            IDiscountPolicy policy = new StandardDiscountPolicy();
            //if (driver.FirstName.Contains("a"))
            //    policy = new VipDiscountPolicy();

            return policy;
        }
    }
}
