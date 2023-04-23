using Api.Definitions;
using Api.Features.EmissionScandal.Models;

namespace Api.Features.EmissionScandal.Cases.Create;

public sealed record CreateCaseRequest
{
    public string Manifacturer { get; init; }
    public string Model { get; init; }
    public bool HasInsurance { get; init; }
    public int PurchaseYear { get; init; }
    public bool IsNewCar { get; init; }
    public double Price { get; init; }
    public PaymentType PaymentType { get; init; }
    public int ProductionYear { get; init; }
}

public sealed class Endpoint : Endpoint<CreateCaseRequest>
{
    private readonly IRepository<CaseDbModel, Case> _repository;

    public Endpoint(IRepository<CaseDbModel, Case> repository)
    {
        _repository = repository;
    }
    
    public override void Configure()
    {
        Post("/cases/");
        AllowAnonymous();
        Description(b =>
        {
            b.Accepts<CreateCaseRequest>(contentType: "application/json")
             .Produces(statusCode:201)
             .Produces(statusCode:400);
        });
    }

    public override Task HandleAsync(CreateCaseRequest req, CancellationToken ct)
    {
        var id = Guid.NewGuid();
        var newCase = new Case(
            id,
            (Manifacturer)req.Manifacturer,
            (Model)req.Model,
            req.HasInsurance,
            (ProductionYear)req.ProductionYear,
            (PurchaseYear)req.PurchaseYear,
            (PurchasePrice)req.Price,
            req.PaymentType,
            req.IsNewCar
        );

        var dbModel = newCase.Map();
        _repository.Create(dbModel);

        return SendCreatedAtAsync<Endpoint>(new { id = newCase.Id }, null!, cancellation: ct);
    }
}