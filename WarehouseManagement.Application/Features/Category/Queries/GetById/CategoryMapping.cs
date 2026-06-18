namespace WarehouseManagement.Application.Features.Category.Queries.GetById;

internal static class CategoryMapping
{
    internal static CategoryDto ToDto(this Domain.Entities.Category c) => new(
        PublicId: c.PublicId,
        Name: c.Name
    );
}