using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Policies;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class FreeMinutesPolicyFactory
    {
        public IFreeMinutesPolicy Create(Driver driver)
        {
            IFreeMinutesPolicy policy = new FreeMinutesPolicy();
            //if (driver.FirstName.Contains("a"))
            //    policy = new VipDiscountPolicy();

            return policy;
        }
    }
}
