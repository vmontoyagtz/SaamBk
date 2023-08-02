using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuizHistoryEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTrainingQuizHistoryRequest>.WithActionResult<
        ListTrainingQuizHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuizHistory> _repository;

        public List(IRepository<TrainingQuizHistory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuizHistories")]
        [SwaggerOperation(
            Summary = "List TrainingQuizHistories",
            Description = "List TrainingQuizHistories",
            OperationId = "trainingQuizHistories.List",
            Tags = new[] { "TrainingQuizHistoryEndpoints" })
        ]
        public override async Task<ActionResult<ListTrainingQuizHistoryResponse>> HandleAsync(
            [FromQuery] ListTrainingQuizHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTrainingQuizHistoryResponse(request.CorrelationId());

            var spec = new TrainingQuizHistoryGetListSpec();
            var trainingQuizHistories = await _repository.ListAsync(spec);
            if (trainingQuizHistories is null)
            {
                return NotFound();
            }

            response.TrainingQuizHistories = _mapper.Map<List<TrainingQuizHistoryDto>>(trainingQuizHistories);
            response.Count = response.TrainingQuizHistories.Count;

            return Ok(response);
        }
    }
}