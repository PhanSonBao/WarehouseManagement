using MediatR;

namespace WarehouseManagement.Application.Features.Product.Delete;

public record DeleteProductCommand(Guid PublicId) : IRequest<Unit>;