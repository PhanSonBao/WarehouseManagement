using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Product
{
    // Data Annotation
    #region Properties
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int? CategoryId { get; private set; }
    public int? BrandId { get; private set; }
    public bool IsActive { get; private set; }
    public string Variants { get; private set; }
    #endregion

    #region Foreign Keys
    public Category Category { get; private set; }
    public Brand Brand { get; private set; }
    public ProductVariant Variant { get; private set; }
    #endregion

    // Private Constructor
    private Product() { }

    // Factory Method
    public static Product CreateProduct(string name, int? categoryId, bool isActive)
    {
        // Validate Input
        if (name == null)
        {
            throw new DomainException("Name cannot be null");
        }

        return new Product
        {
            PublicId = Guid.NewGuid(),
            Name = name,
            CategoryId = categoryId,
            IsActive = isActive,
        };
    }

    public void Update(string name, int categoryId, bool isActive)
    {
        // Validate Input
        Name = name ?? throw new DomainException("Name cannot be null");
        CategoryId = categoryId;
        IsActive = isActive;
    }

    // Soft Delete Product
    public void Deactive()
    {
        IsActive = false;
    }
}