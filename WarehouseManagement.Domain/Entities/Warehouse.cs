namespace WarehouseManagement.Domain.Entities;

public class Warehouse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private Warehouse() { }
}