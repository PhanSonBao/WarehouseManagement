using MediatR;
using WarehouseManagement.Application.Features.Products.Queries.GetById;

namespace WareHouseManagement.Application.Features.Products.Queries.GetProductById;

// Dùng record, implement IRequest<ProductDto>
// (trả về DTO thay vì Entity — không expose Domain ra ngoài)
public record GetByIdQuery : IRequest<ProductDto>
{
    // Guid Id  — id của product cần lấy
    public Guid Id;
}