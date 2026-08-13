using FluentValidation;

namespace WarehouseManagement.Application.Features.Product.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);

        RuleFor(x=>x.CategoryId).NotEmpty();
    }
}