using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Category.Commands.Create;

public class CreateCategoryHandler(ICategoryRepository categoryRepsository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand categoryCommand, CancellationToken cancellationToken)
    {
        // Call Category.Create from categoryCommand
        var category = Domain.Entities.Category.CreateCategory(categoryCommand.Name);

        await categoryRepsository.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return category.Id;
    }
}