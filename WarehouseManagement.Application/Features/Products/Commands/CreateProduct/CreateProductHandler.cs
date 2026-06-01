using MediatR;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Products.Commands.CreateProduct;

// Logic create product and saving to DB are implemented here
public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Gọi Product.Create(...) với các giá trị từ command
        // (Factory method bạn đã viết trong Domain)
        var product = Product.Create(command.Sku, command.Name, command.CostPrice, command.SalePrice,
            command.CategoryId, command.IsActive);

        // Gọi repository.AddAsync(product, ct)
        await productRepository.AddAsync(product, cancellationToken);
        // Gọi unitOfWork.SaveChangesAsync(ct)
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // Return product.Id
        return product.Id;
    }
}