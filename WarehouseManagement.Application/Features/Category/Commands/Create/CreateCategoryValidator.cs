using FluentValidation;

namespace WarehouseManagement.Application.Features.Category.Commands.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        // Name không được rỗng
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}