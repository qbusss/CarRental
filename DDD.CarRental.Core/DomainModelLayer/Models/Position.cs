using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;

        }

        public Distance CalculateDistance(Position p)
        {
            Distance d = new Distance();

            d.Value = Math.Sqrt((this.X -p.X)^2 + (this.Y-p.Y)^2);

            return d;
        }
    }

}
