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
    
    // Private Constructor for EF
    private InventoryItem() { }
    
    // Factory Method
    /// <summary>
    /// Tạo sản phẩm mới
    /// </summary>
    public static InventoryItem Create(Guid productVariantId, Guid warehouseId, int lowStockThreshold)
    {
        // Validate 
        if (lowStockThreshold < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lowStockThreshold), 
                "Low stock threshold must be > 0");
        }
        
        return new InventoryItem
        {
            ProductVariantId =  productVariantId,
            WarehouseId =   warehouseId,
            LowStockThreshold =  lowStockThreshold,
            Quantity = 0
        };
    }

    /// <summary>
    /// Nhập kho
    /// </summary>
    public void AddStock(int quantity)
    {
        // Validate
        if (quantity <= 0)
        {
            throw new Exception("Quantity must be > 0");
        }

        Quantity += quantity;
    }
    
    /// <summary>
    /// Xuất kho
    /// </summary>
    public void Deduct(int quantity)
    {
        // Validate
        if (quantity <= 0 || Quantity - quantity < 0)
        {
            throw new Exception("Quantity must be > 0");
        }
        
        Quantity -= quantity;
    }


    // Computed Property
    public bool IsLowStock => Quantity <= LowStockThreshold;
}