using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmailAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmailAddressRequest>.WithActionResult<
        UpdateEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddress> _repository;

        public Update(
            IRepository<EmailAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/emailAddresses")]
        [SwaggerOperation(
            Summary = "Updates a EmailAddress",
            Description = "Updates a EmailAddress",
            OperationId = "emailAddresses.update",
            Tags = new[] { "EmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmailAddressResponse>> HandleAsync(
            UpdateEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmailAddressResponse(request.CorrelationId());

            var eamaaaToUpdate = _mapper.Map<EmailAddress>(request);

            var emailAddressToUpdateTest = await _repository.GetByIdAsync(request.EmailAddressId);
            if (emailAddressToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(eamaaaToUpdate);

            var emailAddressUpdatedEvent = new EmailAddressUpdatedEvent(eamaaaToUpdate, "Mongo-History");
            _messagePublisher.Publish(emailAddressUpdatedEvent);

            var dto = _mapper.Map<EmailAddressDto>(eamaaaToUpdate);
            response.EmailAddress = dto;

            return Ok(response);
        }
    }
}