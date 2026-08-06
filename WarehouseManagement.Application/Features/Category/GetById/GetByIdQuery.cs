using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Category.GetById;

public record GetByIdQuery(Guid PublicId) : IRequest<CategoryDto>;