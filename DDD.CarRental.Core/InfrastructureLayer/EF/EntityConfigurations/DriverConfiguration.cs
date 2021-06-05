﻿using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> commentConfiguration)
        {
            // ustawianie klucza głównego
            commentConfiguration.HasKey(c => c.Id);

            // klucz tabeli nie będzie generowany przez EF
            commentConfiguration.Property(v => v.Id).ValueGeneratedNever();

            // wykluczenie DomainsEvents z modelu relacyjnego - nie ma potrzeby zapisywania w bazie zdarzeń domenowych
            commentConfiguration.Ignore(c => c.DomainEvents);

            // ToDo: konfiguracja pozostalych elementów
        }
    }

    
}