using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Product
{
    // Data Annotation
    #region Properties
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int CategoryId { get; private set; }
    public int BrandId { get; private set; }
    public bool IsActive { get; private set; }
    #endregion

    #region Foreign Keys

    public Category Category { get; private set; } = null!;
    public Brand? Brands { get; private set; }
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    #endregion

    // Private Constructor
    private Product(string name)
    {
        Name = name;
    }

    // Factory Method
    public static Product CreateProduct(string name, string? description, int categoryId, int brandId, bool isActive)
    {
        // Validate Input
        if (name == null)
        {
            throw new DomainException("Name cannot be null");
        }

        return new Product(name)
        {
            PublicId = Guid.NewGuid(),
            Name = name,
            Description = description,
            CategoryId = categoryId,
            BrandId =  brandId,
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
    public void Deactivate()
    {
        IsActive = false;
    }

    public void AddVariant(ProductVariant variant)
    {
        Variants.Add(variant);
    }
}