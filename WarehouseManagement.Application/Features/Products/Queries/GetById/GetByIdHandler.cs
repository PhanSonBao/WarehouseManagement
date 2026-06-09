using MediatR;
using WareHouseManagement.Application.Features.Products.Queries.GetProductById;
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
            throw new KeyNotFoundException();
        }
        
        // Return dto
        return new ProductDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Name =  product.Name,
            Description = product.Description,
            CostPrice =  product.CostPrice,
            SalePrice = product.SalePrice,
            Barcode = product.BarCode,
            CategoryId =  product.CategoryId,
            BrandId =  product.BrandId,
            IsActive =  product.IsActive,
        };
    }
}