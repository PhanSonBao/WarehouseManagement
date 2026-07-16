using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Delete;

public class DeleteProductHandler (IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException("Product", command.Name);
        }

        product.Deactive();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}