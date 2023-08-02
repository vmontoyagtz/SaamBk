using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdDiscountCodeRequest>.WithActionResult<
        GetByIdDiscountCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCode> _repository;

        public GetByIdWithIncludes(
            IRepository<DiscountCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodes/i/{DiscountCodeId}")]
        [SwaggerOperation(
            Summary = "Get a DiscountCode by Id With Includes",
            Description = "Gets a DiscountCode by Id With Includes",
            OperationId = "discountCodes.GetByIdWithIncludes",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDiscountCodeResponse>> HandleAsync(
            [FromRoute] GetByIdDiscountCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDiscountCodeResponse(request.CorrelationId());

            var spec = new DiscountCodeByIdWithIncludesSpec(request.DiscountCodeId);

            var discountCode = await _repository.FirstOrDefaultAsync(spec);


            if (discountCode is null)
            {
                return NotFound();
            }

            response.DiscountCode = _mapper.Map<DiscountCodeDto>(discountCode);

            return Ok(response);
        }
    }
}