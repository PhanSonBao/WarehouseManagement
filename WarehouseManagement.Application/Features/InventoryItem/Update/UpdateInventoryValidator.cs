using FluentValidation;

namespace WarehouseManagement.Application.Features.InventoryItem.Update;

public class UpdateInventoryValidator : AbstractValidator<UpdateInventoryCommand>
{
    public UpdateInventoryValidator()
    {
        RuleFor(c => c.VariantId)
            .NotEmpty();

        RuleFor(c => c.WarehouseId)
            .NotEmpty();

        RuleFor(c => c.Quantity)
            .NotEqual(0);
    }
}