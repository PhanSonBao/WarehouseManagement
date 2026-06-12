namespace WarehouseManagement.Domain.Entities;

public class Brand
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }

    public ICollection<Product>? Products { get; private set; } = new List<Product>();
}