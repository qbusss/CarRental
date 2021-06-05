using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public enum unit
    {
        KM = 0,
        MILES = 1
    }

    public class Distance: ValueObject
    {
        public double Value { get; set; }
        public unit Unit { get; set; }

        public Distance()
        {
            this.Value = 0;
            this.Unit = unit.KM;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }


        public void Convert(unit unit)
        {
            if (this.Unit == unit.KM && unit == unit.MILES)
            {
                this.Value = this.Value / 1.609344;
                this.Unit = unit.MILES;
            } 
            else if (this.Unit == unit.MILES && unit == unit.KM)
            {
                this.Value = this.Value * 1.609344;
                this.Unit = unit.KM;
            } 
        }

        public void Convert()
        {
            if (this.Unit == unit.KM)
            {
                this.Value = this.Value / 1.609344;
                this.Unit = unit.MILES;
            }
            else if (this.Unit == unit.MILES)
            {
                this.Value = this.Value * 1.609344;
                this.Unit = unit.KM;
            }
        }

        public Distance AddDistances(Distance d1, Distance d2)
        {
            Distance d3 = new Distance();

            if (d1.Unit == d2.Unit)
            {
                d3.Value = d1.Value + d2.Value;
                d3.Unit = d1.Unit;
                return d3;
            }
            else
            {
                d2.Convert();
                d3.Value = d1.Value + d2.Value;
                d3.Unit = d1.Unit;
                return d3;
            }

        }

        public Distance SubtractDistances(Distance d1, Distance d2)
        {
            Distance d3 = new Distance();

            if (d1.Unit == d2.Unit)
            {
                d3.Value = Math.Abs(d1.Value - d2.Value);
                d3.Unit = d1.Unit;
                return d3;
            }
            else
            {
                d2.Convert();
                d3.Value = Math.Abs(d1.Value - d2.Value);
                d3.Unit = d1.Unit;
                return d3;
            }

        }

        public int Compare(Distance d)
        {
            if (this.Unit == d.Unit)
            {
                return this.Value.CompareTo(d.Value);
            }
            else
            {
                d.Convert();
                return this.Value.CompareTo(d.Value);
            }
        }

        public static bool operator <(Distance d, Distance d2)
        {
            if(d.Unit == d2.Unit)
            {
                return d.Value.CompareTo(d2.Value) < 0;
            }
            else
            {
                d2.Convert();
                return d.Value.CompareTo(d2.Value) < 0;
            }
        }

        public static bool operator >(Distance d, Distance d2)
        {
            if (d.Unit == d2.Unit)
            {
                return d.Value.CompareTo(d2.Value) > 0;
            }
            else
            {
                d2.Convert();
                return d.Value.CompareTo(d2.Value) > 0;
            }
        }

        public static bool operator >=(Distance d, Distance d2)
        {
            if (d.Unit == d2.Unit)
            {
                return d.Value.CompareTo(d2.Value) >= 0;
            }
            else
            {
                d2.Convert();
                return d.Value.CompareTo(d2.Value) >= 0;
            }
        }

        public static bool operator <=(Distance d, Distance d2)
        {
            if (d.Unit == d2.Unit)
            {
                return d.Value.CompareTo(d2.Value) <= 0;
            }
            else
            {
                d2.Convert();
                return d.Value.CompareTo(d2.Value) <= 0;
            }
        }


    }

}
