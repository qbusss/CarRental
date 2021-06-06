using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class CarRepository : Repository<Car>, ICarRepository
    { 
        public CarRepository(CarRentalDbContext context)
            :base(context)
        { }

        public Car Get(long id)
        {
            return _context.Cars
                .Include(c => c.CurrentPosition)
                .Include(c => c.CurrentDistance)
                .Include(c => c.TotalDistance)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public Car GetCarByRegistrationNumber(string registrationNumber)
        {
            return _context.Cars
                .Include(c => c.CurrentPosition)
                .Include(c => c.CurrentDistance)
                .Include(c => c.TotalDistance)
                .Where(c => c.RegistrationNumber == registrationNumber)
                .FirstOrDefault();
        }

        public void ChangePosition(Position position, long carId)
        {
            var car = this.Get(carId);
            car.CurrentPosition = position;
            _context.SaveChanges();
        }
    }
}
