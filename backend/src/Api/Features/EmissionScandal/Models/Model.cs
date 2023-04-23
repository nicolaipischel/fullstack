using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Models;

public record struct Model
{
    public Model(string value)
    {
        Value = Guard.Against.NullOrWhiteSpace(value, nameof(Model), "Model must not be null empty or whitespace");
    }
    public string Value { get; }

    public static implicit operator string(Model m) => m.Value;
    public static explicit operator Model(string s) => new(s);
}