using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Category
{
    #region Data Anootation

    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }

    #endregion

    public ICollection<Product>? Products { get; private set; } = new List<Product>();

    // Private Constructor
    private Category()
    {
    }

    // Factory Method
    public static Category CreateCategory(string name)
    {
        // Validate Input
        if (name == null)
        {
            throw new DomainException("Name cannot be null");
        }

        return new Category
        {
            PublicId = Guid.NewGuid(),
            Name = name
        };
    }
}