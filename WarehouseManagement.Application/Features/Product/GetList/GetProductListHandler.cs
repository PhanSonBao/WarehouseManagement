using MediatR;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Product.GetList;

public class GetProductListHandler(IProductRepository productRepository) : IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetProductListQuery query, CancellationToken ct)
    {
        // Gọi productRepository.GetListAsync(ct)
        // (method đã có sẵn — chỉ lấy IsActive == true)
        var products = await productRepository.GetListAsync(ct);
        
        // Return list dto
        return products.Select(p => p.ToDto()).ToList();
    }
}