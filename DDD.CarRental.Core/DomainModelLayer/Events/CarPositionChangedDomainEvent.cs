using System;
using DDD.SharedKernel.DomainModelLayer.Implementations;


namespace DDD.CarRental.Core.DomainModelLayer.Events
{
	public class CarPositionChangedDomainEvent : DomainEvent
	{
		public int X { get; protected set; }
		public int Y { get; protected set; }
	}
}