using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitEmailAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitEmailAddressRequest>.WithActionResult<
        UpdateBusinessUnitEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public Update(
            IRepository<BusinessUnitEmailAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitEmailAddresses")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitEmailAddress",
            Description = "Updates a BusinessUnitEmailAddress",
            OperationId = "businessUnitEmailAddresses.update",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitEmailAddressResponse>> HandleAsync(
            UpdateBusinessUnitEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitEmailAddressResponse(request.CorrelationId());

            var bueauueasueaToUpdate = _mapper.Map<BusinessUnitEmailAddress>(request);

            var businessUnitEmailAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitEmailAddressToUpdateTest is null)
            {
                return NotFound();
            }

            bueauueasueaToUpdate.UpdateBusinessUnitForBusinessUnitEmailAddress(request.BusinessUnitId);
            bueauueasueaToUpdate.UpdateEmailAddressForBusinessUnitEmailAddress(request.EmailAddressId);
            bueauueasueaToUpdate.UpdateEmailAddressTypeForBusinessUnitEmailAddress(request.EmailAddressTypeId);
            await _repository.UpdateAsync(bueauueasueaToUpdate);

            var businessUnitEmailAddressUpdatedEvent =
                new BusinessUnitEmailAddressUpdatedEvent(bueauueasueaToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitEmailAddressUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitEmailAddressDto>(bueauueasueaToUpdate);
            response.BusinessUnitEmailAddress = dto;

            return Ok(response);
        }
    }
}