using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorAddressRequest>.WithActionResult<
        GetByIdAdvisorAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorAddress> _repository;

        public GetByRelsIds(
            IRepository<AdvisorAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorAddresses/{AddressId}/{AdvisorId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorAddress by rel Ids",
            Description = "Gets a AdvisorAddress by rel Ids",
            OperationId = "advisorAddresses.GetByRelsIds",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorAddressResponse(request.CorrelationId());

            var spec = new AdvisorAddressByRelIdsSpec(request.AddressId, request.AdvisorId);

            var advisorAddress = await _repository.FirstOrDefaultAsync(spec);


            if (advisorAddress is null)
            {
                return NotFound();
            }

            response.AdvisorAddress = _mapper.Map<AdvisorAddressDto>(advisorAddress);

            return Ok(response);
        }
    }
}