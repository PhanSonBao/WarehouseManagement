using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Delete;

public class DeleteProductHandler (IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken ct)
    {
        var product = await productRepository.GetByPublicIdAsync(command.PublicId, ct);
        if (product == null)
        {
            throw new NotFoundException("Product", command.PublicId);
        }

        product.Deactivate();
        
        return Unit.Value;
    }
}