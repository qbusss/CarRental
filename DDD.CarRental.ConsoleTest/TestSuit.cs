using DDD.CarRental.Core.ApplicationLayer.Commands;
using DDD.CarRental.Core.ApplicationLayer.Commands.Handlers;
using DDD.CarRental.Core.ApplicationLayer.Queries;
using DDD.CarRental.Core.ApplicationLayer.Queries.Handlers;
using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.ConsoleTest
{
    public class TestSuit
    {
        private IServiceProvider _serviceProvide;

        private CommandHandler _commandHandler;
        private QueryHandler _queryHandler;

        public TestSuit(IServiceCollection serviceCollection)
        {
            _serviceProvide = serviceCollection.BuildServiceProvider();

            _commandHandler = _serviceProvide.GetRequiredService<CommandHandler>();
            _queryHandler = _serviceProvide.GetRequiredService<QueryHandler>();
        }

        public void Run()
        {
            long carId = 10;
            string registrationNumber = "KR135X";

            long driver1Id = 11;
            string licenceNumber1 = "L11";
            long driver2Id = 12;
            string licenceNumber2 = "L12";

            long rental1Id = 1;
            long rental2Id = 2;

            // ustworzenie samochodu
            _commandHandler.Execute(new CreateCarCommand()
            {
                CarId = carId,
                RegistrationNumber = registrationNumber,
                TotalDistance = 0,
                Status = (CarStatus)CarStatusCommand.Available
            }) ;

            // pobieramy informacje o utworzonym samochodzie 
            Console.WriteLine("Utworzono samochód");
            var cars = _queryHandler.Execute(new GetAllCarsQuery());
            foreach (var car in cars)
            {
                Console.WriteLine($"Id samochodu: {car.Id}, Numer rejestracyjny: {car.RegistrationNumber}");
            }

            //tworzymy dwóch kierowców
            _commandHandler.Execute(new CreateDriverCommand()
            {
                DriverId = driver1Id,
                LicenceNumber = licenceNumber1,
                FirstName = "Jan",
                LastName = "Kowalski",
                FreeMinutes = 0
            });

            _commandHandler.Execute(new CreateDriverCommand()
            {
                DriverId = driver2Id,
                LicenceNumber = licenceNumber2,
                FirstName = "Anna",
                LastName = "Kot",
                FreeMinutes = 0
            });

            // pobieramy info o kierowcach
            Console.WriteLine("Utworzono dwóch kierowców");
            var drivers = _queryHandler.Execute(new GetAllDriversQuery());
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Id kierowcy: {driver.Id}, Imię i nazwisko: {driver.FirstName} {driver.LastName}");
            }

            // kierowca 1 wypożycza samochód
            _commandHandler.Execute(new RentCarCommand()
            {
                RentalId = rental1Id,
                Started = new DateTime().AddHours(1).AddMinutes(2),
                CarId = carId,
                DriverId = driver1Id
            });

            // pobieramy info o wypożyczeniach
            Console.WriteLine("Kierowca 1 wypożycza samochód");
            var rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var rental in rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {rental.Id}, Id kierowcy: {rental.DriverId}, Rozpoczęcie: {rental.Started}, Zakończenie: {rental.Finished}, Do zapłaty: {rental.Total}");
            }

            // kierowca 1 zwraca wypożyczony samochód
            _commandHandler.Execute(new ReturnCarCommand()
            {
                RentalId = rental1Id,
                Finished = new DateTime().AddHours(1).AddMinutes(30)
            });

            // pobieramy info o wypożyczeniach
            Console.WriteLine("Gracz 1 kończy wizytę");
            rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var rental in rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {rental.Id}, Id kierowcy: {rental.DriverId}, Rozpoczęcie: {rental.Started}, Zakończenie: {rental.Finished}, Do zapłaty: {rental.Total}");
            }

            // kierowca 2 wypożycza samochów
            _commandHandler.Execute(new RentCarCommand()
            {
                RentalId = rental2Id,
                Started = new DateTime().AddHours(3).AddMinutes(12),
                CarId = carId,
                DriverId = driver2Id
            });

            // pobieramy info o wypożyczeniach
            Console.WriteLine("Kierowca 2 wypożycza samochód");
            rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var rental in rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {rental.Id}, Id kierowcy: {rental.DriverId}, Rozpoczęcie: {rental.Started}, Zakończenie: {rental.Finished}, Do zapłaty: {rental.Total}");
            }

            // kierowca 2 zwraca wypożyczony samochód
            _commandHandler.Execute(new ReturnCarCommand()
            {
                RentalId = rental2Id,
                Finished = new DateTime().AddHours(4).AddMinutes(15)
            });

            // pobieramy info o wypożyczeniach
            Console.WriteLine("Gracz 2 kończy wizytę");
            rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var rental in rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {rental.Id}, Id kierowcy: {rental.DriverId}, Rozpoczęcie: {rental.Started}, Zakończenie: {rental.Finished}, Do zapłaty: {rental.Total}");
            }

        }
    }
}
