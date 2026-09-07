using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Category.GetById;

public record GetCategoryByIdQuery(Guid PublicId) : IRequest<CategoryDto>;