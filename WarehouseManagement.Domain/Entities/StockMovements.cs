namespace WarehouseManagement.Domain.Entities;

public class StockMovements
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    // Constructor
    private StockMovements() { }
}