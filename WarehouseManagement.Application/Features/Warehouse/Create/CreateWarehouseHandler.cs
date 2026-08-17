using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public class CreateWarehouseHandler(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateWarehouseCommand, Guid>
{
    public async Task<Guid> Handle(CreateWarehouseCommand command, CancellationToken ct)
    {
        var warehouse = Domain.Entities.Warehouse.Create(command.Name);
        await warehouseRepository.AddAsync(warehouse, ct);

        return warehouse.PublicId;
    }
}