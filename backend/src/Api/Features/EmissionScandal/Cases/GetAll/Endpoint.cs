using Api.Definitions;
using Api.Features.EmissionScandal.Models;

namespace Api.Features.EmissionScandal.Cases.GetAll;

public sealed record GetAllCasesReponse
{
    public IEnumerable<CaseDto> Cases { get; init; } = Enumerable.Empty<CaseDto>();
}

public sealed class Endpoint : EndpointWithoutRequest<GetAllCasesReponse>
{
    private readonly IRepository<CaseDbModel,Case> _repository;

    public Endpoint(IRepository<CaseDbModel,Case> repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/cases");
        AllowAnonymous();
        Description(b =>
        {
            b.Produces<GetAllCasesReponse>(statusCode: 200, contentType: "application/json+custom");
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var cases = _repository.List();
        var response = new GetAllCasesReponse { Cases = cases.Select(CaseDto.MapFrom).ToList() };
        await SendAsync(response, cancellation: ct);
    }
}