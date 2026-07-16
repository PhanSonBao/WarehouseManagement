namespace WarehouseManagement.Domain.Entities;

public class Warehouse
{
    #region Properties

    public int Id { get; private set; }
    public Guid PublicId { get; private set; }
    public string Name { get; private set; }
    public string Location { get; private set; }

    #endregion

    #region Foreign key

    public int BranchId { get; private set; }

    #endregion

    // Constructor
    private Warehouse()
    {
        
    }
}