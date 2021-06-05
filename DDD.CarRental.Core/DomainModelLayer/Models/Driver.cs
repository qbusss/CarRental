using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Driver : Entity, IAggregateRoot
    {
        public long DriverId { get; protected set; }
        public long LicenceNumber { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FreeMinutes { get;set; }

        public void AddFreeMinutes(IFreeMinutesPolicy policy/*, int freeMinutes*/)
        {
            this.FreeMinutes += policy ?? throw new ArgumentNullException("Empty discount policy");
        }
    }

}
