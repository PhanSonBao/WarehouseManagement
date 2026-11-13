using WarehouseManagement.Domain.Exceptions;

namespace WarehouseManagement.Domain.Entities;

public class Unit
{
    #region Properties
    public string UnitId { get; private set; }
    public string Name { get; private set; }
    #endregion

    #region Foreign Key

    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();

    #endregion
    
    // Constructor
    private Unit() {}
    
    public static Unit CreateUnit(string name, string unitId)
    {
        if (name == null)
        {
            throw new DomainException("Name cannot be null");
        }

        return new Unit()
        {
            UnitId = unitId, 
            Name = name
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
    
    // Unit
    public void AddVariants(ProductVariant variant)
    {
        Variants.Add(variant);
    }
}