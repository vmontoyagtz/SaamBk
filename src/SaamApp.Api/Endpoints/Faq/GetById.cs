using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Faq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FaqEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdFaqRequest>.WithActionResult<
        GetByIdFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Faq> _repository;

        public GetById(
            IRepository<Faq> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/faqs/{FaqId}")]
        [SwaggerOperation(
            Summary = "Get a Faq by Id",
            Description = "Gets a Faq by Id",
            OperationId = "faqs.GetById",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdFaqResponse>> HandleAsync(
            [FromRoute] GetByIdFaqRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdFaqResponse(request.CorrelationId());

            var faq = await _repository.GetByIdAsync(request.FaqId);
            if (faq is null)
            {
                return NotFound();
            }

            response.Faq = _mapper.Map<FaqDto>(faq);

            return Ok(response);
        }
    }
}