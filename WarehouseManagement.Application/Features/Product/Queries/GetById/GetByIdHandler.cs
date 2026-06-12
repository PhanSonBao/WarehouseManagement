using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, ProductDto>
{
    // 1. Tạo private readonly field cho IProductRepository
    private readonly IProductRepository _productRepository;

    // 2. Nhận IProductRepository trong constructor
    public GetByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(query.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), query.Id);
        }

        // Return dto
        return new ProductDto(
            Id: product.Id,
            PublicId: product.PublicId,
            Name: product.Name,
            Description: product.Description,
            SalePrice: product.SalePrice,
            CostPrice: product.CostPrice,
            Barcode: product.Barcode,
            IsActive: product.IsActive,
            BrandId: product.BrandId,
            CategoryId: product.CategoryId,
            Sku: product.Sku
        );
    }
}