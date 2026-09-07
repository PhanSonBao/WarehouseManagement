using MediatR;
using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Product.Update;

public record UpdateProductCommand(
    Guid PublicId,
    string Name,
    int CategoryId,
    bool IsActive
) : ICommand<Unit>;