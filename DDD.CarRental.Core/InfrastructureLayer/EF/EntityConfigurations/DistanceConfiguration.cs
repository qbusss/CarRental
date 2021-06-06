// ustawianie klucza głównego
using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class DistanceConfiguration : IEntityTypeConfiguration<Distance>
    {
        public void Configure(EntityTypeBuilder<Distance> distanceConfiguration)
        {
            // Obiekty typu Value Object są rozróżnialne na podstawie wartości swoich swoich atrybutów.
            // Nie ma zatem potrzeby aby posiadały unikalny identyfikator (Id).
            // Jeśli chcemy takie obiekty mapować do oddzielnych tabel, taki identyfikator jest jednak potrzebny (będzie pełnił rolę klucza).
            // Dodawanie identyfikatora do klasy Value Object nie jest eleganckim rozwiązaniem.
            // Na szczęście Entity Framework dzięki Fluent API pozwala na dodanie do tabeli ukrytego pola Id (tzw. shadow property).
            // Takie pole będzie istniało w tabeli w bazie danych, ale nie bedzie miało odpowiednika w klasach modelu. 

            // dodawanie pola Id
            distanceConfiguration.Property<long>("Id").IsRequired();

            // ustawianie klucza głównego
            distanceConfiguration.HasKey("Id");
        }
    }
}
