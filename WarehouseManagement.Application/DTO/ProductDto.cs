namespace WarehouseManagement.Application.DTO;

public record ProductDto(
    int Id,
    Guid PublicId,
    string Name,
    string? Description,
    int? CategoryId,
    int? BrandId,
    bool IsActive
);