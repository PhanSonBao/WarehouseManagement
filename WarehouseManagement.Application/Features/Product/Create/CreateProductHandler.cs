using MediatR;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Create;

// Logic create product and saving to DB are implemented here
public class CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand command, CancellationToken ct)
    {
        // Gọi Product.Create(...) với các giá trị từ productCommand
        // (Factory method đã viết trong Domain)
        var product = Domain.Entities.Product.CreateProduct(
            command.Name,
            command.Description,
            command.CategoryId,
            command.BrandId,
            command.IsActive
        );

        foreach (var item in command.Variants)
        {
            var variant = Domain.Entities.ProductVariant.CreateVariant(
                item.Name,
                item.CostPrice,
                item.SalePrice,
                item.Barcode,
                item.Sku
            );
            
            product.AddVariant(variant);
        }

        // Gọi repository.AddAsync(product, ct)
        await productRepository.AddAsync(product, ct);

        return product.PublicId;
    }
}