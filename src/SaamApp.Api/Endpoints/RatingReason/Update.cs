using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.RatingReasonEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateRatingReasonRequest>.WithActionResult<
        UpdateRatingReasonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RatingReason> _repository;

        public Update(
            IRepository<RatingReason> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/ratingReasons")]
        [SwaggerOperation(
            Summary = "Updates a RatingReason",
            Description = "Updates a RatingReason",
            OperationId = "ratingReasons.update",
            Tags = new[] { "RatingReasonEndpoints" })
        ]
        public override async Task<ActionResult<UpdateRatingReasonResponse>> HandleAsync(
            UpdateRatingReasonRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateRatingReasonResponse(request.CorrelationId());

            var rrartrToUpdate = _mapper.Map<RatingReason>(request);

            var ratingReasonToUpdateTest = await _repository.GetByIdAsync(request.RatingReasonId);
            if (ratingReasonToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(rrartrToUpdate);

            var ratingReasonUpdatedEvent = new RatingReasonUpdatedEvent(rrartrToUpdate, "Mongo-History");
            _messagePublisher.Publish(ratingReasonUpdatedEvent);

            var dto = _mapper.Map<RatingReasonDto>(rrartrToUpdate);
            response.RatingReason = dto;

            return Ok(response);
        }
    }
}