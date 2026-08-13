using WarehouseManagement.Domain.Enums;

namespace WarehouseManagement.Domain.Entities;

public class StockMovement
{
    #region Properties

    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public int ProductVariantId { get; private set; }
    public int WarehouseId { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public MovementType MovementType { get; private set; }
    public int OrderNo { get; private set; }
    public DateTime CreateAt { get; private set; }
    public string? Note { get; private set; }

    #endregion

    #region Foreign keys

    #endregion

    // Constructor
    private StockMovement()
    {
    }

    // Factory method
    public static StockMovement Create(int productVariantId, int warehouseId, string name, int quantity,
        MovementType movementType, int orderNo, string? note)
    {
        return new StockMovement
        {
            PublicId = Guid.NewGuid(),
            ProductVariantId = productVariantId,
            WarehouseId = warehouseId,
            Name = name,
            Quantity = quantity,
            MovementType = movementType,
            OrderNo = orderNo,
            CreateAt = DateTime.Now,
            Note = note,
        };
    }
}