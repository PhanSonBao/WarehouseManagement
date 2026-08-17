namespace WarehouseManagement.Domain.Entities;

public class Location
{
    #region Properties

    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public int WarehouseId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    
    #endregion

    #region Foreign Keys

    public  Warehouse Warehouse { get; private set; }

    #endregion
    
    // Constructor
    private Location() {}
    
    // Factory method
    public static Location Create(int warehouseId)
    {
        return new Location
        {
            PublicId = Guid.NewGuid(),
            WarehouseId = warehouseId,
            IsActive = true,
        };
    }
}