using MediatR;

namespace WarehouseManagement.Application.Features.Warehouse.Update;

public record UpdateWarehouseCommand(
    int Id,
    string Name,
    string Address,
    bool IsActive) : IRequest<Unit>;