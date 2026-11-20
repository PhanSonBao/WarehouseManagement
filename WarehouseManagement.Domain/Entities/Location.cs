using WarehouseManagement.Domain.Enums;

namespace WarehouseManagement.Domain.Entities;

public class Location
{
    #region Properties

    public string LocationId { get; private set; }
    public string ZoneId { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public LocationType LocationType { get; private set; }
    public Decimal? MaxWeight { get; private set; }
    public Decimal? MaxVolume { get; private set; }
    public bool IsBlocked { get; private set; } = false;
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    
    #endregion

    #region Foreign Keys 

    public  Zone Zone { get; private set; }

    #endregion
    
    // Constructor
    private Location() {}
    
    // Factory method
    public static Location Create(string zoneId, string name)
    {
        return new Location
        {
            LocationId = Guid.NewGuid().ToString(),
            ZoneId = zoneId,
            Name = name,
            IsActive = true,
        };
    }
}