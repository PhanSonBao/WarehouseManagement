using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Category.Commands.Create;

public class CreateCategoryHandler(ICategoryRepository categoryRepsository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand categoryCommand, CancellationToken cancellationToken)
    {
        // Call Category.Create from categoryCommand
        var category = Domain.Entities.Category.CreateCategory(categoryCommand.Name);

        await categoryRepsository.AddAsync(category, cancellationToken);
        var rows = await unitOfWork.SaveChangesAsync(cancellationToken);
        Console.WriteLine($"Rows = {rows}");
        Console.WriteLine($"CategoryId = {category.Id}");        
        return category.PublicId;
    }
}