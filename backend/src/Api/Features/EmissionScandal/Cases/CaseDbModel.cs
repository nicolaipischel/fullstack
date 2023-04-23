using Api.Definitions;
using Api.Features.EmissionScandal.Models;

namespace Api.Features.EmissionScandal.Cases;

public sealed class CaseDbModel : IEntity, IMapTo<Case>
{
    public Guid Id { get; init; }
    
    public Case Map()
    {
        return new Case(
            Id,
            (Manifacturer)Manifacturer,
            (Model)Model,
            HasInsurance,
            (ProductionYear)ProductionYear,
            (PurchaseYear)PurchaseYear,
            (PurchasePrice)PurchasePrice,
            (PaymentType)PaymentType,
            IsNewCar
        );
    }

    public string Description { get;init; }
    public int  Status  { get;init; }
    public string Manifacturer { get;init; }
    public string Model { get;init; }
    public bool HasInsurance { get;init; }
    public int PurchaseYear { get;init; }
    public bool IsNewCar { get;init; }
    public double PurchasePrice { get;init; }
    public int PaymentType { get;init; }
    public int ProductionYear { get;init; }
}