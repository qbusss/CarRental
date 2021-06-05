using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.InfrastructureLayer;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        void Insert(Rental rental);
        Rental Get(long id);
    }

}
