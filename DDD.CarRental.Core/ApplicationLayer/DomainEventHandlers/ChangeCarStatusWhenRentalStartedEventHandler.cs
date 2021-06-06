using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.ApplicationLayer;

namespace DDD.CarRental.Core.ApplicationLayer.DomainEventListeners
{
    public class ChangeCarStatusWhenRentalStartedEventHandler : IEventHandler<RentalStartedDomainEvent>
    {
        private ICarRepository _carRepository;

        public ChangeCarStatusWhenRentalStartedEventHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Handle(RentalStartedDomainEvent eventData)
        {
            // get room
            var car = _carRepository.Get(eventData.Rental.CarId);

            // set room as busy
            car.EnterCar();
        }
    }
}
