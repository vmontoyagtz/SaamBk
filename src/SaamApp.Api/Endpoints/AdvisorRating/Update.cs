using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorRatingEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorRatingRequest>.WithActionResult<
        UpdateAdvisorRatingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorRating> _repository;

        public Update(
            IRepository<AdvisorRating> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorRatings")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorRating",
            Description = "Updates a AdvisorRating",
            OperationId = "advisorRatings.update",
            Tags = new[] { "AdvisorRatingEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorRatingResponse>> HandleAsync(
            UpdateAdvisorRatingRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorRatingResponse(request.CorrelationId());

            var ardrvrToUpdate = _mapper.Map<AdvisorRating>(request);

            var advisorRatingToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorRatingToUpdateTest is null)
            {
                return NotFound();
            }

            ardrvrToUpdate.UpdateAdvisorForAdvisorRating(request.AdvisorId);
            ardrvrToUpdate.UpdateConversationForAdvisorRating(request.ConversationId);
            ardrvrToUpdate.UpdateCustomerForAdvisorRating(request.CustomerId);
            ardrvrToUpdate.UpdateRatingReasonForAdvisorRating(request.RatingReasonId);
            await _repository.UpdateAsync(ardrvrToUpdate);

            var advisorRatingUpdatedEvent = new AdvisorRatingUpdatedEvent(ardrvrToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorRatingUpdatedEvent);

            var dto = _mapper.Map<AdvisorRatingDto>(ardrvrToUpdate);
            response.AdvisorRating = dto;

            return Ok(response);
        }
    }
}