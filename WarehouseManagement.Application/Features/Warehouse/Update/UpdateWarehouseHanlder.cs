using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Update;

public class UpdateWarehouseHanlder(IWarehouseRepository warehouseRepository)
    : IRequestHandler<UpdateWarehouseCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWarehouseCommand command, CancellationToken ct)
    {
        var warehouse = await warehouseRepository.GetByIdAsync(command.Id, ct);
        if (warehouse == null)
        {
            throw new NotFoundException("Warehouse", command.Name);
        }
        
        warehouse.Update(command.Name, command.Address, command.IsActive);
        
        return Unit.Value;
    }
}