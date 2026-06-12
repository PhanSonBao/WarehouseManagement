using MediatR;

namespace WarehouseManagement.Application.Features.Category.Commands.Create;

public record CreateCategoryCommand : IRequest<String>
{
    // Khai báo các property input từ client gửi lên
    public Guid ProductId { get; init; }
}