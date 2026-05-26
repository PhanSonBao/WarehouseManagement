namespace WarehouseManagement.Domain.Entities;

public class StockMovement
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private StockMovement() { }
}