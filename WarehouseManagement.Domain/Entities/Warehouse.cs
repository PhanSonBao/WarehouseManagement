using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Warehouse
{
    #region Properties

    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public int LocationId { get; private set; }
    public int BrandId { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }

    #endregion

    #region Foreign key

    public Brand Brand { get; private set; }
    public Location Location { get; private set; }

    #endregion

    // Constructor
    private readonly List<Location> _locations = new();
    public IReadOnlyCollection<Location> Locations => _locations.AsReadOnly();
    private Warehouse()
    {
    }

    public static Warehouse Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Name cannot be empty.");
        }
        
        return new Warehouse
        {
            PublicId = Guid.NewGuid(),
            Name = name,
            IsActive = true,
        };
    }

    public void Update(string name, string? address)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Name cannot be empty.");
        }

        Name = name;
        Address = address ?? "";
    }

    public void Deactive()
    {
        IsActive = false;
    }
}