namespace WarehouseManagement.Domain.Entities;

// Size, color
public class ProductVariant
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private ProductVariant() { }
}