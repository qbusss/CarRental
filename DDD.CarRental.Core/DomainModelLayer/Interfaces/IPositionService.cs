using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer;
using System;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IPositionService : IDomainService
    {
        void GeneratePosition(long carId, Car car);
    }
}