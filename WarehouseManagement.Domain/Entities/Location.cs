namespace WarehouseManagement.Domain.Entities;

public class Location
{
    #region Properties

    public string LocationId { get; private set; }
    public string WarehouseId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    
    #endregion

    #region Foreign Keys 

    public  Warehouse Warehouse { get; private set; }

    #endregion
    
    // Constructor
    private Location() {}
    
    // Factory method
    public static Location Create(string warehouseId, string name)
    {
        return new Location
        {
            LocationId = Guid.NewGuid().ToString(),
            WarehouseId = warehouseId,
            Name = name,
            IsActive = true,
        };
    }
}