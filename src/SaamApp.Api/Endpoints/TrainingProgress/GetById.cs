using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingProgressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTrainingProgressRequest>.WithActionResult<
        GetByIdTrainingProgressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingProgress> _repository;

        public GetById(
            IRepository<TrainingProgress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingProgresses/{TrainingProgressId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingProgress by Id",
            Description = "Gets a TrainingProgress by Id",
            OperationId = "trainingProgresses.GetById",
            Tags = new[] { "TrainingProgressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingProgressResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingProgressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingProgressResponse(request.CorrelationId());

            var trainingProgress = await _repository.GetByIdAsync(request.TrainingProgressId);
            if (trainingProgress is null)
            {
                return NotFound();
            }

            response.TrainingProgress = _mapper.Map<TrainingProgressDto>(trainingProgress);

            return Ok(response);
        }
    }
}