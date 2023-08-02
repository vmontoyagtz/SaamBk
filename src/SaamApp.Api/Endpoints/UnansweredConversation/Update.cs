using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.UnansweredConversationEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateUnansweredConversationRequest>.WithActionResult<
        UpdateUnansweredConversationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<UnansweredConversation> _repository;

        public Update(
            IRepository<UnansweredConversation> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/unansweredConversations")]
        [SwaggerOperation(
            Summary = "Updates a UnansweredConversation",
            Description = "Updates a UnansweredConversation",
            OperationId = "unansweredConversations.update",
            Tags = new[] { "UnansweredConversationEndpoints" })
        ]
        public override async Task<ActionResult<UpdateUnansweredConversationResponse>> HandleAsync(
            UpdateUnansweredConversationRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateUnansweredConversationResponse(request.CorrelationId());

            var ucncacToUpdate = _mapper.Map<UnansweredConversation>(request);

            var unansweredConversationToUpdateTest = await _repository.GetByIdAsync(request.UnansweredConversationId);
            if (unansweredConversationToUpdateTest is null)
            {
                return NotFound();
            }

            //ucncacToUpdate.UpdateRegionAreaAdvisorCategoryForUnansweredConversation(request.RegionAreaAdvisorCategoryId);
            //ucncacToUpdate.UpdateCustomerForUnansweredConversation(request.CustomerId);
            //ucncacToUpdate.UpdateInteractionTypeForUnansweredConversation(request.InteractionTypeId);
            await _repository.UpdateAsync(ucncacToUpdate);

            var unansweredConversationUpdatedEvent =
                new UnansweredConversationUpdatedEvent(ucncacToUpdate, "Mongo-History");
            _messagePublisher.Publish(unansweredConversationUpdatedEvent);

            var dto = _mapper.Map<UnansweredConversationDto>(ucncacToUpdate);
            response.UnansweredConversation = dto;

            return Ok(response);
        }
    }
}