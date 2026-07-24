namespace WarehouseManagement.Domain.Entities;

// Size, color
public class ProductVariant
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    public long CostPrice { get; private set; } // Giá nhập
    public long SalePrice { get; private set; } // Giá bán
    public string? Barcode { get; private set; }
    public string? Sku { get; private set; }
    
    // Constructor
    private ProductVariant() { }
}