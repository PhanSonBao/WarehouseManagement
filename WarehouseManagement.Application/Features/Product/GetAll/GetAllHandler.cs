using MediatR;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Features.Product.GetAll;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Queries.GetAll;

public class GetAllHandler(IProductRepository productRepository) : IRequestHandler<GetAllQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        // Gọi productRepository.GetAllAsync(ct)
        // (method đã có sẵn — chỉ lấy IsActive == true)
        var products = await productRepository.GetAllAsync(cancellationToken);

        
        // Return list dto
        return products.Select(p => p.ToDto()).ToList();
    }
}