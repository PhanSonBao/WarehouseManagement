using MediatR;
using WarehouseManagement.Application.DTO;

namespace WarehouseManagement.Application.Features.Product.GetAll;

// Implement Pagination later
public record GetAllQuery : IRequest<IEnumerable<ProductDto>>;