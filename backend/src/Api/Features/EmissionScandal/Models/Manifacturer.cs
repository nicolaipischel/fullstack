using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Models;

public record struct Manifacturer
{
    public Manifacturer(string value)
    {
        Value = Guard.Against.NullOrWhiteSpace(value, nameof(Manifacturer), "Manifacturer must not be null empty or whitespace");
    }
    public string Value { get; }

    public static implicit operator string(Manifacturer m) => m.Value;
    public static explicit operator Manifacturer(string s) => new(s);
}