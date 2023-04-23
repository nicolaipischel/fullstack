using System.Data;

namespace Api.Features.EmissionScandal.Cases.Create;

internal sealed class Validator : Validator<CreateCaseRequest>
{
    public Validator()
    {
        RuleFor(request => request.Manifacturer)
            .NotEmpty().WithMessage("manifacturer is required!");

        RuleFor(request => request.Model)
            .NotEmpty().WithMessage("model is required!");

        RuleFor(request => request.Price)
            .GreaterThan(0).WithMessage("price must be greater than zero");

        RuleFor(request => request.PaymentType).IsInEnum();

        RuleFor(request => request.ProductionYear)
            .GreaterThan(2007).WithMessage("procuction year must be between 2008 and 2022")
            .LessThan(2022).WithMessage("procuction year must be between 2008 and 2022");

        RuleFor(request => request.PurchaseYear)
            .GreaterThan(2012).WithMessage("purchase year must be between 2012 and 2021")
            .LessThan(2022).WithMessage("purchase year must be between 2012 and 2021");
    }
}