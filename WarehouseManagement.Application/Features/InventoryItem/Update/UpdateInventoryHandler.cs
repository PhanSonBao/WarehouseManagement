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
            item = Domain.Entities.InventoryItem.Create(command.VariantId, command.WarehouseId, command.LowStockThreshold);
            await inventoryRepository.AddAsync(item, ct);
        }

        if (command.Quantity > 0)
        {
            item.AddStock(command.Quantity);
        }
        else if (command.Quantity < 0)
        {
            item.Deduct(-command.Quantity);
        }

        try
        {
            await unitOfwork.BeginTransactionAsync(ct);
            await unitOfwork.SaveChangesAsync(ct);
            await unitOfwork.CommitAsync(ct);
        }
        catch
        {
            await unitOfwork.RollbackAsync(ct);
            throw;
        }

        return item.PublicId;
    }
}