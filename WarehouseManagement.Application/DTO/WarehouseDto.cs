namespace WarehouseManagement.Application.DTO;

public record WarehouseDto(
    string WarehouseId,
    string Name,
    string? Address,
    bool IsActive);