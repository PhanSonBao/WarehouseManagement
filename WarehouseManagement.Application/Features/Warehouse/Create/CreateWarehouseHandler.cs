using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public class CreateWarehouseHandler(IWarehouseRepository warehouseRepository)
    : IRequestHandler<CreateWarehouseCommand, string>
{
    public async Task<string> Handle(CreateWarehouseCommand command, CancellationToken ct)
    {
        var warehouse = Domain.Entities.Warehouse.Create(command.Name);
        await warehouseRepository.AddAsync(warehouse, ct);

        return warehouse.WarehouseId;
    }
}