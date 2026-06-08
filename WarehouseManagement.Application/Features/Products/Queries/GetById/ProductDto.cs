namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

public record ProductDto
{
    Guid ProductId;
    string Sku;
    string Name;
    string Description;
    decimal CostPrice;
    decimal SalePrice;
    string? Barcode;
    Guid? CategoryId;
    Guid? BrandId;
    bool IsActive;
}