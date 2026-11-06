using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Category.GetById;

public record GetCategoryByIdQuery(string PublicId) : IRequest<CategoryDto>;