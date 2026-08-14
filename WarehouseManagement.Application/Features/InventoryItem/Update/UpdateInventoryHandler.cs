using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.InventoryItem.Update;

public class UpdateInventoryHandler(IInventoryRepository inventoryRepository, IUnitOfWork unitOfwork)
    : IRequestHandler<UpdateInventoryCommand, Guid>
{
    /// <summary>
    /// Find inventory item, change quantity, create stock movement
    /// </summary>
    public async Task<Guid> Handle(UpdateInventoryCommand command, CancellationToken ct)
    {
        var item = await inventoryRepository.GetByVariantWarehouseAsync(command.VariantId, command.WarehouseId, ct);
        if (item == null)
        {
            item = Domain.Entities.InventoryItem.Create(command.VariantId, command.WarehouseId,
                command.LowStockThreshold);
            await inventoryRepository.AddAsync(item, ct);
        }

        switch (command.Quantity)
        {
            case > 0:
                item.AddStock(command.Quantity);
                break;
            case < 0:
                item.Deduct(-command.Quantity);
                break;
            default:
                throw new Exception("Quantity cannot be zero!");
        }

        var stockMovement = Domain.Entities.StockMovement.Create(command.VariantId, command.WarehouseId, command.Name,
            command.Quantity, command.MovementType, command.OrderNo, command.Note);
        await inventoryRepository.AddMovementAsync(stockMovement, ct);

        return item.PublicId;
    }
}