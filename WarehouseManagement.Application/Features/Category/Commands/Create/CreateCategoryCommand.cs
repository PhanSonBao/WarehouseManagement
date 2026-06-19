using MediatR;

namespace WarehouseManagement.Application.Features.Category.Commands.Create;

public record CreateCategoryCommand : IRequest<Guid>
{
    // Khai báo các property input từ client gửi lên
    public Guid PublicId { get; init; }
    public string Name { get; init; }
}