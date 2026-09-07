using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Warehouse.GetById;

public record GetWarehouseByIdQuery(Guid PublicId) : IRequest<WarehouseDto>;