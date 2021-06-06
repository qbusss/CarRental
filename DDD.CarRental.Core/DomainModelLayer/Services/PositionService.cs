using DDD.CarRental.Core.DomainModelLayer.Factories;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Services
{
    public class PositionService : IPositionService
    {
        private ICarRepository _carRepository;

        public PositionService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        public void GeneratePosition(long carId, Car car)
        {
            Random random = new Random();

            int x = random.Next(0, 180);
            int y = random.Next(0, 90);

            Position position = new Position(x, y);

            this._carRepository.ChangePosition(position, carId);

            car.ChangeCurrentPosition(position);
        }
    }
}
