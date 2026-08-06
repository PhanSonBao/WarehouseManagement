namespace WarehouseManagement.Application.DTO;

public record WarehouseDto(
    int Id,
    Guid PublicId,
    string Name,
    string? Address,
    bool IsActive);