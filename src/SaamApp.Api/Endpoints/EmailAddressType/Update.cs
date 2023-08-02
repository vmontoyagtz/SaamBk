using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.EmailAddressTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateEmailAddressTypeRequest>.WithActionResult<
        UpdateEmailAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddressType> _repository;

        public Update(
            IRepository<EmailAddressType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/emailAddressTypes")]
        [SwaggerOperation(
            Summary = "Updates a EmailAddressType",
            Description = "Updates a EmailAddressType",
            OperationId = "emailAddressTypes.update",
            Tags = new[] { "EmailAddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateEmailAddressTypeResponse>> HandleAsync(
            UpdateEmailAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmailAddressTypeResponse(request.CorrelationId());

            var eatmataatToUpdate = _mapper.Map<EmailAddressType>(request);

            var emailAddressTypeToUpdateTest = await _repository.GetByIdAsync(request.EmailAddressTypeId);
            if (emailAddressTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(eatmataatToUpdate);

            var emailAddressTypeUpdatedEvent = new EmailAddressTypeUpdatedEvent(eatmataatToUpdate, "Mongo-History");
            _messagePublisher.Publish(emailAddressTypeUpdatedEvent);

            var dto = _mapper.Map<EmailAddressTypeDto>(eatmataatToUpdate);
            response.EmailAddressType = dto;

            return Ok(response);
        }
    }
}