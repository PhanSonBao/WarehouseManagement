using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public record CreateWarehouseCommand(string Code, string Name, string? Address, string? Description) : ICommand<string>;