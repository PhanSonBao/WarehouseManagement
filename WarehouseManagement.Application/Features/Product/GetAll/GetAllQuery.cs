using MediatR;
using WarehouseManagement.Application.Features.Product.Queries.GetById;

namespace WarehouseManagement.Application.Features.Product.GetAll;

// Implement Pagination later
public record GetAllQuery : IRequest<IEnumerable<ProductDto>>;