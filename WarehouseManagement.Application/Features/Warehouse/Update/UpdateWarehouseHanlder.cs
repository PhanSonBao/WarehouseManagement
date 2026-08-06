using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Update;

public class UpdateWarehouseHanlder(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateWarehouseCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWarehouseCommand command, CancellationToken cancellationToken)
    {
        var warehouse = await warehouseRepository.GetByIdAsync(command.Id, cancellationToken);
        if (warehouse == null)
        {
            throw new NotFoundException("Warehouse", command.Name);
        }
        
        warehouse.Update(command.Name, command.Address, command.IsActive);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}