using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public class CreateWarehouseHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateWarehouseCommand, int>
{
    public async Task<int> Handle(CreateWarehouseCommand command, CancellationToken cancellationToken)
    {
        var warehouse = Domain.Entities.Warehouse.Create(command.Name);
        await warehouseRepository.AddAsync(warehouse, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return warehouse.Id;
    }
}