using FluentValidation;

namespace WarehouseManagement.Application.Features.Product.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        // Name: không được rỗng, tối đa 200 ký tự
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);

        // CategoryId: không được là Empty
        RuleFor(x=>x.CategoryId).NotEmpty();
    }
}