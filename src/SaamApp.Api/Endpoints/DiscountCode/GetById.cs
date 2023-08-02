using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.DiscountCodeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdDiscountCodeRequest>.WithActionResult<
        GetByIdDiscountCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountCode> _repository;

        public GetById(
            IRepository<DiscountCode> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/discountCodes/{DiscountCodeId}")]
        [SwaggerOperation(
            Summary = "Get a DiscountCode by Id",
            Description = "Gets a DiscountCode by Id",
            OperationId = "discountCodes.GetById",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdDiscountCodeResponse>> HandleAsync(
            [FromRoute] GetByIdDiscountCodeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdDiscountCodeResponse(request.CorrelationId());

            var discountCode = await _repository.GetByIdAsync(request.DiscountCodeId);
            if (discountCode is null)
            {
                return NotFound();
            }

            response.DiscountCode = _mapper.Map<DiscountCodeDto>(discountCode);

            return Ok(response);
        }
    }
}