using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiAreaExpertiseEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiAreaExpertiseRequest>.WithActionResult<
        DeleteAiAreaExpertiseResponse>
    {
        private readonly IRepository<AiAreaExpertise> _aiAreaExpertiseReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiAreaExpertise> _repository;

        public Delete(IRepository<AiAreaExpertise> AiAreaExpertiseRepository,
            IRepository<AiAreaExpertise> AiAreaExpertiseReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiAreaExpertiseRepository;
            _aiAreaExpertiseReadRepository = AiAreaExpertiseReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiAreaExpertises/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiAreaExpertise",
            Description = "Deletes an AiAreaExpertise",
            OperationId = "aiAreaExpertises.delete",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiAreaExpertiseResponse>> HandleAsync(
            [FromRoute] DeleteAiAreaExpertiseRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiAreaExpertiseResponse(request.CorrelationId());

            var aiAreaExpertise = await _aiAreaExpertiseReadRepository.GetByIdAsync(request.RowId);

            if (aiAreaExpertise == null)
            {
                return NotFound();
            }


            var aiAreaExpertiseDeletedEvent = new AiAreaExpertiseDeletedEvent(aiAreaExpertise, "Mongo-History");
            _messagePublisher.Publish(aiAreaExpertiseDeletedEvent);

            await _repository.DeleteAsync(aiAreaExpertise);

            return Ok(response);
        }
    }
}