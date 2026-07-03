using MediatR;

namespace WarehouseManagement.Application.Features.Product.Commands.Delete;

public record DeleteProductCommand(Guid PublicId, string Name) : IRequest<Unit>;