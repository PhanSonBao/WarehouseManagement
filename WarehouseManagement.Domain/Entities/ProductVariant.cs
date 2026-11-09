using WarehouseManagement.Domain.Exceptions;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Entities;

// Size, color
public class ProductVariant
{
    #region Properties
    public int Id { get; private set; }
    public string PublicId { get; private set; }
    public int ProductId { get; private set; }
    public string UnitId { get; private set; }
    public string Name { get; private set; }
    public long CostPrice { get; private set; }
    public long SalePrice { get; private set; }
    public string? Barcode { get; private set; }
    public string? Sku { get; private set; }
    #endregion
    
    #region Foreign keys
    public Product Product { get; private set; }
    public Unit Unit { get; private set; }
    
    #endregion
    
    // Constructor
    private ProductVariant() { }
    
    // Factory Method
    public static ProductVariant CreateVariant(string name, int productId, string unitId, long costPrice, long salePrice, string? barcode,
        string? sku)
    {
        if (name == null)
        {
            throw new DomainException("Name cannot be null");
        }
        
        return new ProductVariant
        {
            PublicId = Guid.NewGuid().ToString(),
            ProductId = productId,
            UnitId = unitId,
            Name = name,
            CostPrice = costPrice,
            SalePrice = salePrice,
            Barcode = barcode,
            Sku = sku
        };
    }
}