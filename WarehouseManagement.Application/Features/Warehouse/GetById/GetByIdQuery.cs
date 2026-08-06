using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Warehouse.GetById;

public record GetByIdQuery(Guid PublicId) : IRequest<WarehouseDto>;