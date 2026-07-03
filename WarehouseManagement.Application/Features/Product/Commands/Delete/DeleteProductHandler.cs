using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Commands.Delete;

public class DeleteProductHandler (IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand commnad, CancellationToken cancellationToken)
    {
        var product = productRepository.GetByPublicIdAsync(commnad.PublicId, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException("Product", commnad.Name);
        }

        product.Deactive(commnad.PublicId);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}