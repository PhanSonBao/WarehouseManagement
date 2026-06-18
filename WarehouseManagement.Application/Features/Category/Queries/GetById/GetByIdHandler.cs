using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Category.Queries.GetById;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    // Receive ICateogoryRepository in constructor
    public GetByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByPublicIdAsync(query.PublicId, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), query.PublicId);
        }

        // Return mapping dto
        return category.ToDto();
    }
}