using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FaqEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListFaqRequest>.WithActionResult<ListFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Faq> _repository;

        public List(IRepository<Faq> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/faqs")]
        [SwaggerOperation(
            Summary = "List Faqs",
            Description = "List Faqs",
            OperationId = "faqs.List",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<ListFaqResponse>> HandleAsync([FromQuery] ListFaqRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListFaqResponse(request.CorrelationId());

            var spec = new FaqGetListSpec();
            var faqs = await _repository.ListAsync(spec);
            if (faqs is null)
            {
                return NotFound();
            }

            response.Faqs = _mapper.Map<List<FaqDto>>(faqs);
            response.Count = response.Faqs.Count;

            return Ok(response);
        }
    }
}