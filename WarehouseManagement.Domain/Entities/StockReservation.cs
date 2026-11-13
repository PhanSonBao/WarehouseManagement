namespace WarehouseManagement.Domain.Entities;

public class StockReservation
{
    #region Properties
    public int InventoryItemId { get; private set; }
    public int OutboundOrderLineId { get; private set; }
    #endregion
    
    #region Foreign Keys
    public InventoryItem InventoryItem { get; private set; }
    public OutboundOrderLine OutboundOrderLine { get; private set; }
    #endregion
    
    // Constructor
    private StockReservation() {}
    
}