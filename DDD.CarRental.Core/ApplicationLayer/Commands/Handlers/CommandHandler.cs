using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Factories;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Services;
using Microsoft.EntityFrameworkCore;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System.Linq;


namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
    public class CommandHandler
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private DiscountPolicyFactory _discountPolicyFactory;
        private RentalFactory _rentalFactory;
        private FreeMinutesFactory _freeMinutesFactory;

        public CommandHandler(ICarRentalUnitOfWork _unitOfWork, DiscountPolicyFactory discountPolicyFactory, RentalFactory rentalFactory, FreeMinutesFactory freeMinutesFactory)
        {
            _unitOfWork = unitOfWork;
            _discountPolicyFactory = discountPolicyFactory;
            _rentalFactory = rentalFactory;
            _freeMinutesFactory = freeMinutesFactory;
        }

        public void Execute(CreateCarCommand command)
        {
            Car car = this._unitOfWork.CarRepository.Get(command.CarId);
            if (car != null) throw new Exception($"Car '{command.CarId}' already exists.");
            car = this._unitOfWork.CarRepository.GetCarByRegistrationNumber(command.RegistrationNumber);
            if (car != null) throw new Exception($"Car '{command.RegistrationNumber}' already exists.");

            car = new Car(command.CarId, command.RegistrationNumber, command.TotalDistance, command.Status);
            this._unitOfWork.CarRepository.Insert(car);
            this._unitOfWork.Commit();
        }

        public void Execute(CreatePlayerCommand command)
        {
            Driver driver = this._unitOfWork.DriverRepository.Get(command.DriverId);
            if (driver != null) throw new Exception($"Driver '{command.DriverId}' already exists.");
            driver = this._unitOfWork.DriverRepository.GetDriverByLicenceNumber(command.LicenceNumber);
            if (driver != null) throw new Exception($"Driver '{command.LicenceNumber}' already exists.");

            driver = new Driver(command.DriverId, command.LicenceNumber, command.FirstName, command.LastName, command.FreeMinutes);

            this._unitOfWork.DriverRepository.Insert(driver);
            this._unitOfWork.Commit();
        }

        public void Execute(RentCarCommand command)
        {
            Car car = this._unitOfWork.CarRepository.Get(command.CarId)
                ?? throw new Exception($"Could not find car '{command.CarId}'.");
            Driver driver = this._unitOfWork.DriverRepository.Get(command.DriverId)
                ?? throw new Exception($"Could not find driver '{command.DriverId}'.");

            Rental rental = this._rentalFactory.Create(command.RentalId, command.Started, driver, car);
            IDiscountPolicy policy = this._discountPolicyFactory.Create(driver);
            rental.RegisterPolicy(policy);

            this._unitOfWork.RentalRepository.Insert(rental);
            this._unitOfWork.Commit();
        }

        public void Execute(ReturnCarCommand command)
        {
            Rental rental = this._unitOfWork.RentalRepository.Get(command.RentalId)
                ?? throw new Exception($"Could not find rental '{command.RentalId}'.");
            Car car = this._unitOfWork.CarRepository.Get(rental.CarId)
                ?? throw new Exception($"Could not find car '{rental.CarId}'.");
            Driver driver = this._unitOfWork.DriverRepository.Get(rental.DriverId)
                ?? throw new Exception($"Could not find driver '{rental.DriverId}'.");

            car.ChangeStatus();

            IFreeMinutesPolicy policy = this._freeMinutesFactory.Create(Driver driver);
            driver.AddFreeMinutes(policy);

            rental.StopRental(command.Finished)
        }
    }
}
