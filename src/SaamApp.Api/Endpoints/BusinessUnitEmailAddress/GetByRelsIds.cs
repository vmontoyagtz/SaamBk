using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEmailAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsBusinessUnitEmailAddressRequest>.
        WithActionResult<
            GetByIdBusinessUnitEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public GetByRelsIds(
            IRepository<BusinessUnitEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitEmailAddresses/{BusinessUnitId}/{EmailAddressId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitEmailAddress by rel Ids",
            Description = "Gets a BusinessUnitEmailAddress by rel Ids",
            OperationId = "businessUnitEmailAddresses.GetByRelsIds",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsBusinessUnitEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitEmailAddressResponse(request.CorrelationId());

            var spec = new BusinessUnitEmailAddressByRelIdsSpec(request.BusinessUnitId, request.EmailAddressId);

            var businessUnitEmailAddress = await _repository.FirstOrDefaultAsync(spec);


            if (businessUnitEmailAddress is null)
            {
                return NotFound();
            }

            response.BusinessUnitEmailAddress = _mapper.Map<BusinessUnitEmailAddressDto>(businessUnitEmailAddress);

            return Ok(response);
        }
    }
}