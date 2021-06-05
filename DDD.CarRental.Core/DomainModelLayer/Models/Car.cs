using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public enum CarStatus
    {
        Available = 0,
        Reserved = 1,
        Rented = 2
    }

    public class Car : Entity, IAggregateRoot
    {
        public long CarId { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public Distance CurrentDistance { get; protected set; }
        public Distance TotalDistance { get; protected set; }
        public Position CurrentPosition { get; set; }
        public CarStatus Status { get; protected set; }

        public void ChangeStatus()
        {
            this.Status = CarStatus.Available;
        }
    }

}
