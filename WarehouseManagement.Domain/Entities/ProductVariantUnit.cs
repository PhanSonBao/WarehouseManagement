namespace WarehouseManagement.Domain.Entities;

public class ProductVariantUnit
{
    #region Properties

    public int Id { get; private set; }
    public int ProductVariantId { get; private set; }
    public string UnitId { get; private set; }

    #endregion
    
    #region Foreign keys
    public ProductVariant ProductVariant { get; private set; }
    public Unit Unit { get; private set; }
    #endregion
    
    // Constructor
    private ProductVariantUnit() {}
}