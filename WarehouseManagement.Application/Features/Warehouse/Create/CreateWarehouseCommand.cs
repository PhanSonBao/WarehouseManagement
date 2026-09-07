using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public record CreateWarehouseCommand(string Name, string? Address) : ICommand<Guid>;