using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiFeedbackEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAiFeedbackRequest>.WithActionResult<ListAiFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiFeedback> _repository;

        public List(IRepository<AiFeedback> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiFeedbacks")]
        [SwaggerOperation(
            Summary = "List AiFeedbacks",
            Description = "List AiFeedbacks",
            OperationId = "aiFeedbacks.List",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<ListAiFeedbackResponse>> HandleAsync(
            [FromQuery] ListAiFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiFeedbackResponse(request.CorrelationId());

            var spec = new AiFeedbackGetListSpec();
            var aiFeedbacks = await _repository.ListAsync(spec);
            if (aiFeedbacks is null)
            {
                return NotFound();
            }

            response.AiFeedbacks = _mapper.Map<List<AiFeedbackDto>>(aiFeedbacks);
            response.Count = response.AiFeedbacks.Count;

            return Ok(response);
        }
    }
}