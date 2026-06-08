using AutoMapper;
using MediatR;
using WareHouseManagement.Application.Features.Products.Queries.GetProductById;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, ProductDto>
{
    // 1. Tạo private readonly field cho IProductRepository
    private readonly IProductRepository productRepository;
    
    // 2. Nhận IProductRepository trong constructor
    public GetByIdHandler()
    {
        this.productRepository = productRepository;
    }
    
    public async Task<ProductDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        // Map Product entity sang ProductDto
        // Gợi ý: return new ProductDto(product.Id, product.SKU, ...)

        // Return dto

        var product = await productRepository.GetByIdAsync(query.Id, cancellationToken);
        if (product == null)
        {
            throw new KeyNotFoundException();
        }

        Mapper.CreateMap<Product, ProductDto>();

        return new ProductDto(
        {
            product.Id
        });
        
        return ProductDto;
    }
}