using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Product
{
    // Data Annotaion
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Sku { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal CostPrice { get; private set; } // Giá nhập
    public decimal SalePrice { get; private set; } // Giá bán
    public string? Barcode { get; private set; }
    public int? CategoryId { get; private set; }
    public int? BrandId { get; private set; }
    public bool IsActive { get; private set; }
    public string? Variants { get; private set; }

    #region Foreign Keys
    public Category Category { get; private set; }
    public Brand Brand { get; private set; }
    #endregion

    // Private Constructor
    private Product() { }

    // Factory Method
    public static Product CreateProduct(string? sku, string name, decimal costPrice, decimal salePrice, int? categoryId,
        bool isActive)
    {
        // Validate Input
        if (name == null || salePrice <= 0)
        {
            throw new DomainException("Name cannot be null and Sale Price must be > 0");
        }

        return new Product
        {
            PublicId = Guid.NewGuid(),
            Sku = sku,
            Name = name,
            CostPrice = costPrice,
            SalePrice = salePrice,
            CategoryId = categoryId,
            IsActive = isActive,
        };
    }

    public void UpdateProduct(string sku, string name, decimal costPrice, decimal salePrice, int categoryId, bool isActive)
    {
        // Validate Input
        if (name == null || salePrice <= 0)
        {
            throw new DomainException("Name cannot be null and Sale Price must be > 0");
        }

        Sku = sku;
        Name = name;
        CostPrice = costPrice;
        SalePrice = salePrice;
        CategoryId = categoryId;
        IsActive = isActive;
    }

    // Soft Delete Product
    public void Deactive()
    {
        IsActive = false;
    }
}