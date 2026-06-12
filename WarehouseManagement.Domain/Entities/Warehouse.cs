namespace WarehouseManagement.Domain.Entities;

public class Warehouse
{
    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private Warehouse() { }
}