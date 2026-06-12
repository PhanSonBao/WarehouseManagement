using MediatR;

namespace WarehouseManagement.Application.Features.Products.Queries.GetById;

// Dùng record, implement IRequest<ProductDto>
// (trả về DTO thay vì Entity — không expose Domain ra ngoài)
public record GetByIdQuery : IRequest<ProductDto>
{
    // Guid Id  — id của product cần lấy
    public int Id;
    
    // Constructor
    public GetByIdQuery(int id)
    {
        Id = id;
    }
}