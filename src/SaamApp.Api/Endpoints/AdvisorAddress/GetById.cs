using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorAddressRequest>.WithActionResult<
        GetByIdAdvisorAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorAddress> _repository;

        public GetById(
            IRepository<AdvisorAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorAddress by Id",
            Description = "Gets a AdvisorAddress by Id",
            OperationId = "advisorAddresses.GetById",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorAddressResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorAddressResponse(request.CorrelationId());

            var advisorAddress = await _repository.GetByIdAsync(request.RowId);
            if (advisorAddress is null)
            {
                return NotFound();
            }

            response.AdvisorAddress = _mapper.Map<AdvisorAddressDto>(advisorAddress);

            return Ok(response);
        }
    }
}