using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Brand
{
    #region Properties
    public string BrandId { get; private set; }
    public string Name { get; private set; }
    #endregion

    #region Foreign Keys
    public ICollection<Product>? Products { get; private set; } = new List<Product>();
    #endregion
    
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
            BrandId = Guid.NewGuid().ToString(),
            Name = name
        };
    }
}