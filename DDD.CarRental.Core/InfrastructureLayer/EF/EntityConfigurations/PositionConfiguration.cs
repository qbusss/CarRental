using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> positionConfiguration)
        {
            positionConfiguration.Property<long>("Id").IsRequired();

            positionConfiguration.HasKey("Id");
        }
    }
}
