using MediatR;
using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Delete;

public record DeleteProductCommand(string PublicId) : ICommand<Unit>;