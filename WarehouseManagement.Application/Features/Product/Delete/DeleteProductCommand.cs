using MediatR;

namespace WarehouseManagement.Application.Features.Product.Delete;

public record DeleteProductCommand(int Id, string Name) : IRequest<Unit>;