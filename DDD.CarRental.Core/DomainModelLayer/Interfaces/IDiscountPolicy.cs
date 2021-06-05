
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IDiscountPolicy
    {
        string Name { get; }
        Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice);
    }
}