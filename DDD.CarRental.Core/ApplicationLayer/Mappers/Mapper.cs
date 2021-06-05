using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Mappers
{
    public class Mapper
    {
        // ToDo: zaimplementwać mapery obiektów biznesowych na transferowe

        public DriverDto Map(Driver d)
        {
            return new DriverDto()
            {
                Id = d.Id,
                LicenceNumber = d.LicenceNumber,
                FirstName = d.FirstName,
                LastName = d.LastName,
            };
        }

        public CarDto Map(Car car)
        {
            return new CarDto()
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                CurrentDistance = car.CurrentDistance,
                TotalDistance = car.TotalDistance,
                Status = (CarStatusDto)car.Status,
            };
        }

        public RentalDto Map(Rental r)
        {
            return new RentalDto()
            {
                Id = r.Id,
                Started = r.Started,
                Finished = r.Finished,
                Total = r.Total.Amount,

            };
        }
    }
}
