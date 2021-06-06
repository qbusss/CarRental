using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Policies;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class FreeMinutesPolicyFactory
    {
        public IFreeMinutesPolicy Create()
        {
            IFreeMinutesPolicy policy = new FreeMinutesPolicy();

            return policy;
        }
    }
}
