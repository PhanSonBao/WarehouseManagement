using WarehouseManagement.Application.Common.Interfaces;

namespace WarehouseManagement.Application.Features.Category.Create;

public record CreateCategoryCommand(string Name) : ICommand<Guid>;