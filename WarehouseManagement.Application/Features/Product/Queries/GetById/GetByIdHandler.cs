using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

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
        var product = await _productRepository.GetByPublicIdAsync(query.PublicId, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), query.PublicId);
        }

        // Return dto - Already Mapping
        return product.ToDto();
    }
}