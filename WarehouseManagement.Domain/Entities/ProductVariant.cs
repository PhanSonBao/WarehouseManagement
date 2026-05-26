namespace WarehouseManagement.Domain.Entities;

// Size, color
public class ProductVariant
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private ProductVariant() { }
}