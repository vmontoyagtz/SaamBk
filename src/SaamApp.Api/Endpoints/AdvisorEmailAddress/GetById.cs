using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEmailAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorEmailAddressRequest>.WithActionResult<
        GetByIdAdvisorEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public GetById(
            IRepository<AdvisorEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorEmailAddress by Id",
            Description = "Gets a AdvisorEmailAddress by Id",
            OperationId = "advisorEmailAddresses.GetById",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorEmailAddressResponse(request.CorrelationId());

            var advisorEmailAddress = await _repository.GetByIdAsync(request.RowId);
            if (advisorEmailAddress is null)
            {
                return NotFound();
            }

            response.AdvisorEmailAddress = _mapper.Map<AdvisorEmailAddressDto>(advisorEmailAddress);

            return Ok(response);
        }
    }
}