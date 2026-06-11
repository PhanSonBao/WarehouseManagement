using MediatR;

namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

// Dùng record, implement IRequest<ProductDto>
// (trả về DTO thay vì Entity — không expose Domain ra ngoài)
public record GetByIdQuery : IRequest<ProductDto>
{
    // Guid Id  — id của product cần lấy
    public Guid Id;
    
    // Constructor
    public GetByIdQuery(Guid id)
    {
        Id = id;
    }
}