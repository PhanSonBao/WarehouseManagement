namespace WarehouseManagement.Domain.Entities;

public class ProductVariants
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private ProductVariants() { }
}