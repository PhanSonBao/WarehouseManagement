using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Commands.Create;

// Logic create product and saving to DB are implemented here
public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand productCommand, CancellationToken cancellationToken)
    {
        // Gọi Product.Create(...) với các giá trị từ productCommand
        // (Factory method đã viết trong Domain)
        var product = Domain.Entities.Product.CreateProduct(productCommand.Sku,
            productCommand.Name, productCommand.CostPrice,
            productCommand.SalePrice, productCommand.CategoryId, productCommand.IsActive);

        // Gọi repository.AddAsync(product, ct)
        await productRepository.AddAsync(product, cancellationToken);
        // Gọi unitOfWork.SaveChangesAsync(ct)
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // Return product.Id
        return product.Id;
    }
}