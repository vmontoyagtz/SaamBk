using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PhoneNumberTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePhoneNumberTypeRequest>.WithActionResult<
        UpdatePhoneNumberTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumberType> _repository;

        public Update(
            IRepository<PhoneNumberType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/phoneNumberTypes")]
        [SwaggerOperation(
            Summary = "Updates a PhoneNumberType",
            Description = "Updates a PhoneNumberType",
            OperationId = "phoneNumberTypes.update",
            Tags = new[] { "PhoneNumberTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePhoneNumberTypeResponse>> HandleAsync(
            UpdatePhoneNumberTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePhoneNumberTypeResponse(request.CorrelationId());

            var pnthntontToUpdate = _mapper.Map<PhoneNumberType>(request);

            var phoneNumberTypeToUpdateTest = await _repository.GetByIdAsync(request.PhoneNumberTypeId);
            if (phoneNumberTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(pnthntontToUpdate);

            var phoneNumberTypeUpdatedEvent = new PhoneNumberTypeUpdatedEvent(pnthntontToUpdate, "Mongo-History");
            _messagePublisher.Publish(phoneNumberTypeUpdatedEvent);

            var dto = _mapper.Map<PhoneNumberTypeDto>(pnthntontToUpdate);
            response.PhoneNumberType = dto;

            return Ok(response);
        }
    }
}