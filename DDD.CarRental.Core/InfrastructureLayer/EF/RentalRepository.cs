using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(CarRentalDbContext context)
            : base(context)
        { }

        public void Insert(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        public Rental Get(long id)
        {
            return _context.Rentals
                .Where(d => d.Id == id)
                .FirstOrDefault();
        }
    }
}
