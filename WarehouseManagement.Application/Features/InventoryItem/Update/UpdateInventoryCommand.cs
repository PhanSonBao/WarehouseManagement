using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.InventoryItem.Update;

public record UpdateInventoryCommand(
    string Name,
    int VariantId,
    int WarehouseId,
    int Quantity,
    int OrderNo,
    string Note,
    int LowStockThreshold,
    Domain.Enums.MovementType MovementType
) : ICommand<Guid>;