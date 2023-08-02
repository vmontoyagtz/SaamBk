using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AddressTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAddressTypeRequest>.WithActionResult<
        UpdateAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AddressType> _repository;

        public Update(
            IRepository<AddressType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/addressTypes")]
        [SwaggerOperation(
            Summary = "Updates a AddressType",
            Description = "Updates a AddressType",
            OperationId = "addressTypes.update",
            Tags = new[] { "AddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAddressTypeResponse>> HandleAsync(
            UpdateAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAddressTypeResponse(request.CorrelationId());

            var atdtdtToUpdate = _mapper.Map<AddressType>(request);

            var addressTypeToUpdateTest = await _repository.GetByIdAsync(request.AddressTypeId);
            if (addressTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(atdtdtToUpdate);

            var addressTypeUpdatedEvent = new AddressTypeUpdatedEvent(atdtdtToUpdate, "Mongo-History");
            _messagePublisher.Publish(addressTypeUpdatedEvent);

            var dto = _mapper.Map<AddressTypeDto>(atdtdtToUpdate);
            response.AddressType = dto;

            return Ok(response);
        }
    }
}