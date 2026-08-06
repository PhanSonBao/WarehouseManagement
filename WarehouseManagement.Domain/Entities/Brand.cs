using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Brand
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }

    public ICollection<Product>? Products { get; private set; } = new List<Product>();
    
    // Constructor
    private Brand() { }
    
    // Factory method
    public Brand CreateBrand(string name)
    {
        if (name == null)
        {
            throw new DomainException("Brand name cannot be null.");
        }
        
        return new Brand
        {
            PublicId = Guid.NewGuid(),
            Name = name
        };
    }
}