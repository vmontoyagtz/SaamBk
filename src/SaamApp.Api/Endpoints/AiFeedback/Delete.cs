using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiFeedbackEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiFeedbackRequest>.WithActionResult<
        DeleteAiFeedbackResponse>
    {
        private readonly IRepository<AiFeedback> _aiFeedbackReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiFeedback> _repository;

        public Delete(IRepository<AiFeedback> AiFeedbackRepository, IRepository<AiFeedback> AiFeedbackReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiFeedbackRepository;
            _aiFeedbackReadRepository = AiFeedbackReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiFeedbacks/{AiFeedbackId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiFeedback",
            Description = "Deletes an AiFeedback",
            OperationId = "aiFeedbacks.delete",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiFeedbackResponse>> HandleAsync(
            [FromRoute] DeleteAiFeedbackRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiFeedbackResponse(request.CorrelationId());

            var aiFeedback = await _aiFeedbackReadRepository.GetByIdAsync(request.AiFeedbackId);

            if (aiFeedback == null)
            {
                return NotFound();
            }


            var aiFeedbackDeletedEvent = new AiFeedbackDeletedEvent(aiFeedback, "Mongo-History");
            _messagePublisher.Publish(aiFeedbackDeletedEvent);

            await _repository.DeleteAsync(aiFeedback);

            return Ok(response);
        }
    }
}