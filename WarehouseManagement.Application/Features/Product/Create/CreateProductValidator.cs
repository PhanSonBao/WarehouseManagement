using FluentValidation;

namespace WarehouseManagement.Application.Features.Product.Commands.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        // SKU: không được rỗng, tối đa 50 ký tự
        // RuleFor(x => x.Sku).NotEmpty().MaximumLength(50);

        // Name: không được rỗng, tối đa 200 ký tự
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);

        // CostPrice: phải >= 0
        RuleFor(x => x.CostPrice).NotEmpty().GreaterThanOrEqualTo(0);

        // SalePrice: phải > 0, và phải >= CostPrice
        RuleFor(x => x.SalePrice)
            .NotEmpty()
            .GreaterThan(0)
            .GreaterThanOrEqualTo(x => x.CostPrice);

        // CategoryId: không được là Empty
        RuleFor(x=>x.CategoryId).NotEmpty();
    }
}