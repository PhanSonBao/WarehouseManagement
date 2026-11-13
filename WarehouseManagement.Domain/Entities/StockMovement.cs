using WarehouseManagement.Domain.Enums;

namespace WarehouseManagement.Domain.Entities;

public class StockMovement
{
    #region Properties

    public int Id { get; private set; }
    public int InventoryItemId { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public MovementType MovementType { get; private set; }
    public int OrderNo { get; private set; }
    public DateTime CreateAt { get; private set; }
    public string? Note { get; private set; }

    #endregion

    #region Foreign keys
    public InventoryItem InventoryItem { get; private set; }
    #endregion

    // Constructor
    private StockMovement()
    {
    }

    // Factory method
    public static StockMovement Create(int inventoryItemId, string name, int quantity,
        MovementType movementType, int orderNo, string? note)
    {
        return new StockMovement
        {
            InventoryItemId = inventoryItemId,
            Name = name,
            Quantity = quantity,
            MovementType = movementType,
            OrderNo = orderNo,
            CreateAt = DateTime.Now,
            Note = note,
        };
    }
}