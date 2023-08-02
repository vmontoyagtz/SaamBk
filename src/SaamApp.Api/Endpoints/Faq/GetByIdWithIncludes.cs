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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdFaqRequest>.WithActionResult<
        GetByIdFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Faq> _repository;

        public GetByIdWithIncludes(
            IRepository<Faq> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/faqs/i/{FaqId}")]
        [SwaggerOperation(
            Summary = "Get a Faq by Id With Includes",
            Description = "Gets a Faq by Id With Includes",
            OperationId = "faqs.GetByIdWithIncludes",
            Tags = new[] { "FaqEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdFaqResponse>> HandleAsync(
            [FromRoute] GetByIdFaqRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdFaqResponse(request.CorrelationId());

            var spec = new FaqByIdWithIncludesSpec(request.FaqId);

            var faq = await _repository.FirstOrDefaultAsync(spec);


            if (faq is null)
            {
                return NotFound();
            }

            response.Faq = _mapper.Map<FaqDto>(faq);

            return Ok(response);
        }
    }
}