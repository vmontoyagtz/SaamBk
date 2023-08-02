using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitPhoneNumberEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsBusinessUnitPhoneNumberRequest>.
        WithActionResult<
            GetByIdBusinessUnitPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public GetByRelsIds(
            IRepository<BusinessUnitPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitPhoneNumbers/{BusinessUnitId}/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitPhoneNumber by rel Ids",
            Description = "Gets a BusinessUnitPhoneNumber by rel Ids",
            OperationId = "businessUnitPhoneNumbers.GetByRelsIds",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsBusinessUnitPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitPhoneNumberResponse(request.CorrelationId());

            var spec = new BusinessUnitPhoneNumberByRelIdsSpec(request.BusinessUnitId, request.PhoneNumberId);

            var businessUnitPhoneNumber = await _repository.FirstOrDefaultAsync(spec);


            if (businessUnitPhoneNumber is null)
            {
                return NotFound();
            }

            response.BusinessUnitPhoneNumber = _mapper.Map<BusinessUnitPhoneNumberDto>(businessUnitPhoneNumber);

            return Ok(response);
        }
    }
}