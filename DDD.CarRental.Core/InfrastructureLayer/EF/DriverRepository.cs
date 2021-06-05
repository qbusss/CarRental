using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(CarRentalDbContext context)
            : base(context)
        { }

        public Driver Get(long Id)
        {
            return _context.Drivers
                .Where(d => d.Id == id)
                .FirstOrDefault();
        }

        public Driver GetDriverByLicenceNumber(string licenceNumber)
        {
            return _context.Drivers
                .Where(d => d.LicenceNumber == licenceNumber)
                .FirstOrDefault();
        }
    }
}
