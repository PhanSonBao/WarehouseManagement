using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Update;

public class UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException("Product", command.Name);
        }

        product.Update(command.Sku, command.Name, command.CostPrice,
            command.SalePrice, command.CategoryId, command.IsActive);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}