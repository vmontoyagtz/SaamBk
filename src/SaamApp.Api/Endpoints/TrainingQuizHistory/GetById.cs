using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuizHistoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTrainingQuizHistoryRequest>.WithActionResult<
        GetByIdTrainingQuizHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuizHistory> _repository;

        public GetById(
            IRepository<TrainingQuizHistory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuizHistories/{TrainingQuizHistoryId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingQuizHistory by Id",
            Description = "Gets a TrainingQuizHistory by Id",
            OperationId = "trainingQuizHistories.GetById",
            Tags = new[] { "TrainingQuizHistoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingQuizHistoryResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingQuizHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingQuizHistoryResponse(request.CorrelationId());

            var trainingQuizHistory = await _repository.GetByIdAsync(request.TrainingQuizHistoryId);
            if (trainingQuizHistory is null)
            {
                return NotFound();
            }

            response.TrainingQuizHistory = _mapper.Map<TrainingQuizHistoryDto>(trainingQuizHistory);

            return Ok(response);
        }
    }
}