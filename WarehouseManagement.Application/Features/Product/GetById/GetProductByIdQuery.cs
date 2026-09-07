using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Product.GetById;

// Dùng record, implement IRequest<ProductDto>
// (trả về DTO thay vì Entity — không expose Domain ra ngoài)
public record GetProductByIdQuery(Guid PublicId) : IRequest<ProductDto>;