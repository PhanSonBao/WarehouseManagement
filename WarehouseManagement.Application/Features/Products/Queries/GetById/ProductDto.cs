namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

public record ProductDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public string? Barcode { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? BrandId { get; set; }
    public bool IsActive { get; set; }
}