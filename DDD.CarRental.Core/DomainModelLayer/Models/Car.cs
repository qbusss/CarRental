using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;

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

        public string RegistrationNumber { get; protected set; }
        public Distance CurrentDistance { get; protected set; }
        public Distance TotalDistance { get; protected set; }
        public Position CurrentPosition { get; set; }
        public CarStatus Status { get; protected set; }

        protected Car() { }

        public Car(long carId, string registrationNumber)
            : base(carId)
        {
            if (String.IsNullOrEmpty(registrationNumber)) throw new Exception("Car registration number is null or empty");

            Distance initialDistance = new Distance();
            Position position = new Position(0, 0);

            RegistrationNumber = registrationNumber;
            CurrentPosition = position;
            CurrentDistance = initialDistance;
            TotalDistance = initialDistance;
            Status = CarStatus.Available;

        }

        public void ChangeStatus()
        {
            this.Status = CarStatus.Available;
        }

        public void EnterCar()
        {
            this.Status = CarStatus.Rented;
        }

        public void ChangeCurrentPosition(Position position)
        {
            this.CurrentPosition = position;
        }
    }

}
