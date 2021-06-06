using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> carConfiguration)
        {
            // ustawianie klucza głównego
            carConfiguration.HasKey(car => car.Id);

            // klucz tabeli nie będzie generowany przez EF
            carConfiguration.Property(c => c.Id).ValueGeneratedNever();

            // rejestracja samochodu ma być unikalna
            carConfiguration.HasIndex(r => r.RegistrationNumber).IsUnique();

            // wykluczenie DomainsEvents z modelu relacyjnego
            carConfiguration.Ignore(c => c.DomainEvents);

            // mechanizm OwnOne dodaje nowe pola do wyjściowej tabeli 
            // dla porównania zob. mapowanie dla klasy Score, która jest również typu Value object - tam jest tworzona nowa tabela
            carConfiguration.OwnsOne(r => r.CurrentPosition);
        }
    }
}





