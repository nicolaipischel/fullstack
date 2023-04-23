using Api.Features.EmissionScandal.Models;
using Ardalis.GuardClauses;

namespace Api.Features.EmissionScandal.Cases;

public sealed class Case
{
    public Case(
        Guid caseId,
        Manifacturer manifacturer,
        Model model,
        bool hasInsurance,
        ProductionYear productionYear,
        PurchaseYear purchaseYear,
        PurchasePrice purchasePrice,
        PaymentType paymentType,
        bool isNewCar,
        string description = "",
        CaseStatus status = CaseStatus.New)
    {
        Id = caseId;
        Manifacturer = Guard.Against.Null(manifacturer);
        Model = Guard.Against.Null(model);
        HasInsurance = hasInsurance;
        ProductionYear = Guard.Against.Null(productionYear);
        PurchaseYear = Guard.Against.Null(purchaseYear);
        PurchasePrice = Guard.Against.Null(purchasePrice);
        PaymentType = Guard.Against.EnumOutOfRange(paymentType);
        IsNewCar = isNewCar;
        Status = status;
        Description = description;
    }
    public Guid Id { get; init; }
    public string Description { get; }
    public CaseStatus Status  { get; }
    public Manifacturer Manifacturer { get; }
    public Model Model { get; }
    public bool HasInsurance { get; }
    public PurchaseYear PurchaseYear { get; }
    public bool IsNewCar { get; }
    public PurchasePrice PurchasePrice { get; }
    public PaymentType PaymentType { get; }
    public ProductionYear ProductionYear { get; }

    public CaseDbModel Map()
    {
        return new CaseDbModel
        {
            Id = Id,
            Description = Description,
            Manifacturer = Manifacturer,
            Model = Model,
            Status = (int)Status,
            HasInsurance = HasInsurance,
            PaymentType = (int)PaymentType,
            ProductionYear = ProductionYear,
            PurchasePrice = PurchasePrice,
            PurchaseYear = PurchaseYear,
            IsNewCar = IsNewCar
        };
    }
}