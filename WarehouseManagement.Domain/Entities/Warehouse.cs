using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Warehouse
{
    #region Properties

    public string WarehouseId { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    #endregion

    #region Foreign key

    public ICollection<InventoryItem> InventoryItems { get; private set; } = new List<InventoryItem>();
    public ICollection<Zone> Zones { get; private set; } = new List<Zone>();

    #endregion

    // Constructor
    private Warehouse()
    {
    }

    public static Warehouse Create(string code, string name, string? address, string? description)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Name cannot be empty.");
        }

        return new Warehouse
        {
            WarehouseId = Guid.NewGuid().ToString(),
            Code = code,
            Name = name,
            Address =  address ?? string.Empty,
            Description = description ?? string.Empty,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public void Update(string name, string? address, bool isActive, DateTime? updatedAt)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Name cannot be empty.");
        }

        Name = name;
        Address = address ?? "";
        IsActive = isActive;
        UpdatedAt = (DateTime)updatedAt!;
    }

    public void Deactive()
    {
        IsActive = false;
    }
}