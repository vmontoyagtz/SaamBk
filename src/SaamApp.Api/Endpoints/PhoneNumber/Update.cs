using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PhoneNumberEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePhoneNumberRequest>.WithActionResult<
        UpdatePhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumber> _repository;

        public Update(
            IRepository<PhoneNumber> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/phoneNumbers")]
        [SwaggerOperation(
            Summary = "Updates a PhoneNumber",
            Description = "Updates a PhoneNumber",
            OperationId = "phoneNumbers.update",
            Tags = new[] { "PhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePhoneNumberResponse>> HandleAsync(
            UpdatePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePhoneNumberResponse(request.CorrelationId());

            var pnhnonToUpdate = _mapper.Map<PhoneNumber>(request);

            var phoneNumberToUpdateTest = await _repository.GetByIdAsync(request.PhoneNumberId);
            if (phoneNumberToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(pnhnonToUpdate);

            var phoneNumberUpdatedEvent = new PhoneNumberUpdatedEvent(pnhnonToUpdate, "Mongo-History");
            _messagePublisher.Publish(phoneNumberUpdatedEvent);

            var dto = _mapper.Map<PhoneNumberDto>(pnhnonToUpdate);
            response.PhoneNumber = dto;

            return Ok(response);
        }
    }
}