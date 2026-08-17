using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Category.Create;

public class CreateCategoryHandler(ICategoryRepository categoryRepsository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken ct)
    {
        // Call Category.Create from categoryCommand
        var category = Domain.Entities.Category.CreateCategory(command.Name);

        await categoryRepsository.AddAsync(category, ct);

        return category.PublicId;
    }
}