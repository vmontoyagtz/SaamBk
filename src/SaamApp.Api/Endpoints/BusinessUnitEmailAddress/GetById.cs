using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEmailAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitEmailAddressRequest>.WithActionResult<
        GetByIdBusinessUnitEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public GetById(
            IRepository<BusinessUnitEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitEmailAddress by Id",
            Description = "Gets a BusinessUnitEmailAddress by Id",
            OperationId = "businessUnitEmailAddresses.GetById",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitEmailAddressResponse(request.CorrelationId());

            var businessUnitEmailAddress = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitEmailAddress is null)
            {
                return NotFound();
            }

            response.BusinessUnitEmailAddress = _mapper.Map<BusinessUnitEmailAddressDto>(businessUnitEmailAddress);

            return Ok(response);
        }
    }
}