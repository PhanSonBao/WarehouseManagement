namespace WarehouseManagement.Domain.Entities;

public class InventoryItem
{
    // Properties
    public Guid Id { get; private set; }
    public Guid ProductVariantId { get; private set; }
    public Guid WarehouseId { get; private set; }
    public int Quantity { get; private set; }
    public int LowStockThreshold { get; private set; } // Ngưỡng cảnh báo tồn kho thấp
    public byte[] RowVersion { get; private set; } // Concurrency token
    
    // Constructor
    private InventoryItem() { }
    
    // Factory Method
    /// <summary>
    /// Tạo sản phẩm mới
    /// </summary>
    public static InventoryItem Create(Guid productVariantId, Guid warehouseId, int lowStockThreshold)
    {
        int quantity = 0;

        return new InventoryItem
        {

        };
    }

    /// <summary>
    /// Nhập kho
    /// </summary>
    public static InventoryItem AddStock(int quantity)
    {
        // Validate
        if (quantity < 0)
        {
            throw new CannotUnloadAppDomainException();
        }

        InventoryItem.AddStock(quantity);
        return new InventoryItem
        {
            Quantity =  quantity
        };
    }
    
    /// <summary>
    /// Xuất kho
    /// </summary>
    public static InventoryItem Deduct(int quantity)
    {

        return new InventoryItem
        {

        };
    }
    
    
}