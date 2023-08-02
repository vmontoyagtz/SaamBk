using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitAddressRequest>.WithActionResult<
        UpdateBusinessUnitAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public Update(
            IRepository<BusinessUnitAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitAddresses")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitAddress",
            Description = "Updates a BusinessUnitAddress",
            OperationId = "businessUnitAddresses.update",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitAddressResponse>> HandleAsync(
            UpdateBusinessUnitAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitAddressResponse(request.CorrelationId());

            var buauuasuaToUpdate = _mapper.Map<BusinessUnitAddress>(request);

            var businessUnitAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitAddressToUpdateTest is null)
            {
                return NotFound();
            }

            buauuasuaToUpdate.UpdateAddressForBusinessUnitAddress(request.AddressId);
            buauuasuaToUpdate.UpdateAddressTypeForBusinessUnitAddress(request.AddressTypeId);
            buauuasuaToUpdate.UpdateBusinessUnitForBusinessUnitAddress(request.BusinessUnitId);
            await _repository.UpdateAsync(buauuasuaToUpdate);

            var businessUnitAddressUpdatedEvent =
                new BusinessUnitAddressUpdatedEvent(buauuasuaToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitAddressUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitAddressDto>(buauuasuaToUpdate);
            response.BusinessUnitAddress = dto;

            return Ok(response);
        }
    }
}