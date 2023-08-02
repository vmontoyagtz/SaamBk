using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiAreaExpertiseEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiAreaExpertiseRequest>.WithActionResult<
        UpdateAiAreaExpertiseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiAreaExpertise> _repository;

        public Update(
            IRepository<AiAreaExpertise> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiAreaExpertises")]
        [SwaggerOperation(
            Summary = "Updates a AiAreaExpertise",
            Description = "Updates a AiAreaExpertise",
            OperationId = "aiAreaExpertises.update",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiAreaExpertiseResponse>> HandleAsync(
            UpdateAiAreaExpertiseRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAiAreaExpertiseResponse(request.CorrelationId());

            var aaeiaeaeToUpdate = _mapper.Map<AiAreaExpertise>(request);

            var aiAreaExpertiseToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (aiAreaExpertiseToUpdateTest is null)
            {
                return NotFound();
            }

            aaeiaeaeToUpdate.UpdateRegionAreaAdvisorCategoryForAiAreaExpertise(request.RegionAreaAdvisorCategoryId);
            await _repository.UpdateAsync(aaeiaeaeToUpdate);

            var aiAreaExpertiseUpdatedEvent = new AiAreaExpertiseUpdatedEvent(aaeiaeaeToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiAreaExpertiseUpdatedEvent);

            var dto = _mapper.Map<AiAreaExpertiseDto>(aaeiaeaeToUpdate);
            response.AiAreaExpertise = dto;

            return Ok(response);
        }
    }
}