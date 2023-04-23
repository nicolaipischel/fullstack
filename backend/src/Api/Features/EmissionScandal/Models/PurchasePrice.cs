using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Models;

public sealed class PurchasePrice
{
    public PurchasePrice(double value)
    {
        Value = Guard.Against.NegativeOrZero(value, nameof(PurchasePrice), "Purchase price must be greater than zero");
    }
    public double Value { get; }

    public static implicit operator double(PurchasePrice m) => m.Value;
    public static explicit operator PurchasePrice(double i) => new(i);
}