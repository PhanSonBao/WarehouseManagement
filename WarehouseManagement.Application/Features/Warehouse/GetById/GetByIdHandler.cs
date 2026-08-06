using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.GetById;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, WarehouseDto>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public GetByIdHandler(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<WarehouseDto> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var warehouse = await _warehouseRepository.GetByPublicIdAsync(query.PublicId, cancellationToken);
        if (warehouse == null)
        {
            throw new NotFoundException(nameof(Warehouse), query.PublicId);
        }

        return warehouse.ToDto();
    }
}