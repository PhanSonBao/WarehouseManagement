using MediatR;

namespace WarehouseManagement.Application.Features.Product.Queries.GetById;

// Dùng record, implement IRequest<ProductDto>
// (trả về DTO thay vì Entity — không expose Domain ra ngoài)
public record GetByIdQuery(Guid PublicId) : IRequest<ProductDto>
{
    // Id của product cần lấy
    public Guid PublicId = PublicId;
}