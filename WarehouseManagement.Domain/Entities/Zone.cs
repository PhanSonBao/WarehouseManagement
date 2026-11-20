using WarehouseManagement.Domain.Enums;
using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Zone
{
    #region Properties

    public string ZoneId { get; private set; }
    public string WarehouseId { get; private set; }
    public string Name { get; private set; }
    public ZoneType ZoneType { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    #endregion

    #region Foreign Key

    public Warehouse Warehouse { get; private set; }
    public ICollection<Location> Locations { get; private set; } = new List<Location>();

    #endregion

    // Constructor
    private Zone()
    {
    }

    public static Zone Create(string warehouseId, string name, ZoneType zoneType)
    {
        if (string.IsNullOrEmpty(warehouseId) || string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("WarehouseId and Name cannot be null");
        }

        return new Zone
        {
            ZoneId = Guid.NewGuid().ToString(),
            WarehouseId = warehouseId,
            Name = name,
            ZoneType = zoneType
        };
    }
}