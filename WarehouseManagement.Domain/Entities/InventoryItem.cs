using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class InventoryItem
{
    #region Properties
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public int VariantId { get; private set; }
    public int WarehouseId { get; private set; }
    public int Quantity { get; private set; }
    public int LowStockThreshold { get; private set; } // Ngưỡng cảnh báo tồn kho thấp
    public byte[] RowVersion { get; private set; } // Concurrency token
    #endregion

    #region Foreign Keys
    public ProductVariant ProductVariant { get; private set; }
    public Warehouse Warehouse { get; private set; }
    #endregion
    
    // Private Constructor for EF
    private InventoryItem() { }
    
    // Factory Method
    /// <summary>
    /// Create new
    /// </summary>
    public static InventoryItem Create(int variantId, int warehouseId, int lowStockThreshold)
    {
        // Validate 
        if (lowStockThreshold < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lowStockThreshold), 
                "Low stock threshold must be > 0");
        }
        
        return new InventoryItem
        {
            PublicId = Guid.NewGuid(),
            VariantId =  variantId,
            WarehouseId =   warehouseId,
            LowStockThreshold =  lowStockThreshold,
            Quantity = 0
        };
    }

    /// <summary>
    /// Import
    /// </summary>
    public void AddStock(int quantity)
    {
        // Validate
        if (quantity <= 0)
        {
            throw new DomainException("Quantity must be > 0");
        }

        Quantity += quantity;
    }
    
    /// <summary>
    /// Export
    /// </summary>
    public void Deduct(int quantity)
    {
        // Validate
        if (quantity <= 0 || Quantity - quantity < 0)
        {
            throw new DomainException("Quantity must be > 0");
        }
        
        Quantity -= quantity;
    }


    // Computed Property
    public bool IsLowStock => Quantity <= LowStockThreshold;
}