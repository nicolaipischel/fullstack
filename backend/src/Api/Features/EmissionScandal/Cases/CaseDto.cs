using Api.Definitions;

namespace Api.Features.EmissionScandal.Cases;

public sealed record CaseDto : IMapFrom<Case, CaseDto>
{
    public Guid Id { get; init; }
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
    
    public static CaseDto MapFrom(Case input)
    {
        return new CaseDto
        {
            Id = input.Id,
            Description = input.Description,
            Manifacturer = input.Manifacturer,
            Model = input.Model,
            Status = (int)input.Status,
            HasInsurance = input.HasInsurance,
            PaymentType = (int)input.PaymentType,
            ProductionYear = input.ProductionYear,
            PurchasePrice = input.PurchasePrice,
            PurchaseYear = input.PurchaseYear,
            IsNewCar = input.IsNewCar
        };
    }
}