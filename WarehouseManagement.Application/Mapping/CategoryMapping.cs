using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Mapping;

internal static class CategoryMapping
{
    internal static CategoryDto ToDto(this Domain.Entities.Category c) => new(
        PublicId: c.PublicId,
        Name: c.Name
    );
}