namespace WarehouseManagement.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string SKU { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int CostPrice { get; private set; } // Giá nhập
    public int SalePrice { get; private set; } // Giá bán
    public string? BarCode { get; private set; }
    public string CategoryId { get; private set; }
    public Guid? BrandId { get; private set; }
    public bool IsActive { get; private set; }

    // Private Constructor
    private Product() { }

    // Factory Method
    public static Product Create(Guid id, string sku, string name, int costPrice, int salePrice, string categoryId, bool isActive)
    {
        // Validate Input
        if (name == null || salePrice <= 0)
        {
            throw new CannotUnloadAppDomainException();
        }

        return new Product
        {
            Id = Guid.NewGuid(),
            SKU = sku,
            Name = name,
            CostPrice = costPrice,
            SalePrice = salePrice,
            CategoryId = categoryId,
            IsActive = isActive,
        };
    }

    public static Product Update(Guid id, string sku, string name, int costPrice, int salePrice, string categoryId, bool isActive)
    {
        // Validate Input
        if (name == null || salePrice <= 0)
        {
            throw new CannotUnloadAppDomainException();
        }

        return new Product
        {
            Id = Guid.NewGuid(),
            SKU = sku,
            Name = name,
            CostPrice = costPrice,
            SalePrice = salePrice,
            CategoryId = categoryId,
            IsActive = isActive,
        };
    }
    
    // Soft Delete Product
    public static Product Deactivate(Guid id)
    {
        // Search product id
        if (id != Guid.Empty) {}

        return new Product
        {
            IsActive = false
        };
    }
}