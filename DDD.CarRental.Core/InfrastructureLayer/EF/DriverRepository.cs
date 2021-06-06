using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(CarRentalDbContext context)
            : base(context)
        { }

     //   public Driver Get(long id)
       // {
        //    return _context.Drivers
        //        .Where(d => d.Id == id)
        //        .FirstOrDefault();
       // }

        public Driver GetDriverByLicenceNumber(long licenceNumber)
        {
            return _context.Drivers
                .Where(d => d.LicenceNumber == licenceNumber)
                .FirstOrDefault();
        }
    }
}
