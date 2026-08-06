using WarehouseManagement.Application.DTO;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Application.Mapping;

internal static class WarehouseMapping
{
    internal static WarehouseDto ToDto(this Warehouse w) => new(
    Id: w.Id,
    PublicId: w.PublicId,
    Name: w.Name,
    Address: w.Address,
    IsActive: w.IsActive);
}