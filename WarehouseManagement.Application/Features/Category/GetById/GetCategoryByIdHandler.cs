using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Category.GetById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    // Receive ICateogoryRepository in constructor
    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery query, CancellationToken ct)
    {
        var category = await _categoryRepository.GetByPublicIdAsync(query.PublicId, ct);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), query.PublicId);
        }

        // Return mapping dto
        return category.ToDto();
    }
}