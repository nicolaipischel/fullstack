using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Models;

public record struct PurchaseYear
{
    public PurchaseYear(int value)
    {
        Value = Guard.Against.OutOfRange(value, nameof(Model),2012, 2021, "Purchase Year must be between 2012 and 2021");
    }
    public int Value { get; }

    public static implicit operator int(PurchaseYear m) => m.Value;
    public static explicit operator PurchaseYear(int i) => new(i);
}