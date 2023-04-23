using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Models;

public record struct ProductionYear
{
    public ProductionYear(int value)
    {
        Value = Guard.Against.OutOfRange(value, nameof(Model),2008, 2021, "Production Year must be between 2008 and 2021");
    }
    public int Value { get; }

    public static implicit operator int(ProductionYear m) => m.Value;
    public static explicit operator ProductionYear(int i) => new(i);
}