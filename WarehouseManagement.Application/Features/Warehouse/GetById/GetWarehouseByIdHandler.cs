using MediatR;
using WarehouseManagement.Application.Common.Exceptions;
using WarehouseManagement.Application.DTO;
using WarehouseManagement.Application.Mapping;
using WarehouseManagement.Domain.Interfaces;

namespace WarehouseManagement.Application.Features.Warehouse.GetById;

public class GetWarehouseByIdHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseDto>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public GetWarehouseByIdHandler(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<WarehouseDto> Handle(GetWarehouseByIdQuery query, CancellationToken ct)
    {
        var warehouse = await _warehouseRepository.GetByPublicIdAsync(query.PublicId, ct);
        if (warehouse == null)
        {
            throw new NotFoundException(nameof(Warehouse), query.PublicId);
        }

        return warehouse.ToDto();
    }
}