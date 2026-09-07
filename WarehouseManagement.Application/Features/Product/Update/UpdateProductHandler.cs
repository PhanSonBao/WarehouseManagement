using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Update;

public class UpdateProductHandler(IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken ct)
    {
        var product = await productRepository.GetByPublicIdAsync(command.PublicId, ct);
        if (product == null)
        {
            throw new NotFoundException("Product", command.PublicId);
        }

        product.Update(command.Name, command.CategoryId, command.IsActive);
        
        return Unit.Value;
    }
}