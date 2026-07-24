using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.GetById;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, ProductDto>
{
    // 1. Create private readonly field for IProductRepository
    private readonly IProductRepository _productRepository;

    // 2. Inject IProductRepository into the constructor
    public GetByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByPublicIdAsync(query.PublicId, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), query.PublicId);
        }

        // Return dto - Already Mapping
        return product.ToDto();
    }
}