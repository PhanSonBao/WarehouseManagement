using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Category.Queries.GetById;

public record GetByIdQuery(Guid PublicId) : IRequest<CategoryDto>
{
    // Id Category need
    public Guid PublicId = PublicId;
}