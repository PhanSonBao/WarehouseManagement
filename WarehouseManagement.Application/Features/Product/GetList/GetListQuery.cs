using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Product.GetList;

// Implement Pagination later
public record GetListQuery : IRequest<IEnumerable<ProductDto>>;