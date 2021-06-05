using Dapper;
using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Queries.Handlers
{
    public class QueryHandler
    {
        private CarRentalDbContext _dbContext;
        private Mapper _mapper;


        public QueryHandler(CarRentalDbContext context, Mapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }


        public List<DriverDto> Execute(GetAllDriversQuery query)
        {
            var drivers = _dbContext.Drivers
                .AsNoTracking()
                .ToList();


            List<DriverDto> result =drivers.Select(r => this._mapper.Map(r)).ToList();

            return result;
        }


        public List<CarDto> Execute(GetAllCarsQuery query)
        {
            var cars = _dbContext.Cars
                .AsNoTracking()
                .ToList();

            List<CarDto> result = cars.Select(r => this._mapper.Map(r)).ToList();

            return result;
        }


        public List<RentalDto> Execute(GetAllRentalsQuery query)
        {
            string sql =
                $@"SELECT 
                    r.Id, 
                    r.Started, 
                    r.Finished, 
                    r.Total_Currency,
                    r.Total_Amount,
                    r.DriverId,
                    r.CarId, 
                FROM Rentals r 
                INNER JOIN Drivers d 
                    ON r.DriverId = d.Id 
                INNER JOIN Cars c 
                    ON r.CarId = c.Id";

            var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var rentalViews = connection.Query<RentalDto>(sql)
                    .ToList();

                foreach (var r in rentalViews)
                {
                    if (r.Finished.HasValue)
                       r.TimeInMinutes = (r.Finished.Value - r.Started).Minutes;
                }

                return rentalViews;
            }
        }

        public DriverDto Execute(GetDriverQuery query)
        {
            Driver driver = _dbContext.Drivers
                .AsNoTracking()
                .Where(r => r.Id == query.DriverId)
                .FirstOrDefault();

            if (driver == null)
                throw new Exception($"Could not find driver '{query.DriverId}'");

            DriverDto result = this._mapper.Map(driver);

            return result;

        }

        public CarDto Execute(GetCarQuery query)
        {
            Car car = _dbContext.Cars
                .AsNoTracking()
                .Where(r => r.Id == query.CarId)
                .FirstOrDefault();

            if (car == null)
                throw new Exception($"Could not find car '{query.CarId}'");

            CarDto result = this._mapper.Map(car);

            return result;
        }



        public RentalDto Execute(GetRentalQuery query)
        {
            string sql =
                $@"SELECT 
                    r.RentalId, 
                    r.Started, 
                    r.Finished, 
                    r.Total_Currency,
                    r.Total_Amount,
                    r.DriverId,
                    r.CarId, 
                FROM Rentals r 
                INNER JOIN Drivers d
                    ON r.DriverId = d.DriverId 
                INNER JOIN cars c
                    ON r.CarId = c.CarId
                WHERE r.RentalId = @rentalId";

            var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                var rentalDto = connection.QueryFirstOrDefault<RentalDto>(sql, new { visitId = query.RentalId });

                if (rentalDto.Finished.HasValue) rentalDto.TimeInMinutes = (rentalDto.Finished.Value - rentalDto.Started).Minutes;

                return rentalDto;
            }

        }






    }
}
