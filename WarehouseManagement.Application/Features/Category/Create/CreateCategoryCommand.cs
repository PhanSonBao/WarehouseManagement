using MediatR;

namespace WarehouseManagement.Application.Features.Category.Create;

public record CreateCategoryCommand(string Name) : IRequest<Guid>;