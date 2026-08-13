using MediatR;

namespace WarehouseManagement.Application.Features.Product.Update;

public record UpdateProductCommand(
    int Id,
    Guid PublicId,
    string Name,
    int CategoryId,
    bool IsActive
) : IRequest<Unit>;