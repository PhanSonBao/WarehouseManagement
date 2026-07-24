using MediatR;

namespace WarehouseManagement.Application.Features.Warehouse.Create;

public record CreateWarehouseCommand(string Name, string? Address) : IRequest<int>;