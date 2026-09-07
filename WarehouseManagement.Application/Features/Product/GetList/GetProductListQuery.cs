using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Product.GetList;

// Implement Pagination later
public record GetProductListQuery : IRequest<IEnumerable<ProductDto>>;