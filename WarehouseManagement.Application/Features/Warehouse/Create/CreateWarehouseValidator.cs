using FluentValidation;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public class CreateWarehouseValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseValidator()
    {
        RuleFor(w => w.Code)
            .MaximumLength(50)
            .NotEmpty();
            
        RuleFor(w => w.Name)
            .MaximumLength(250)
            .NotEmpty();

        RuleFor(w => w.Address)
            .MaximumLength(500);
    }
}