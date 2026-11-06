using MediatR;
using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.Update;

public record UpdateWarehouseCommand(
    string WarehouseId,
    string Name,
    string Address,
    bool IsActive) : ICommand<Unit>;