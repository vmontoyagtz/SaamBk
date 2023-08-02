using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitPhoneNumberEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitPhoneNumberRequest>.WithActionResult<
        GetByIdBusinessUnitPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public GetById(
            IRepository<BusinessUnitPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitPhoneNumber by Id",
            Description = "Gets a BusinessUnitPhoneNumber by Id",
            OperationId = "businessUnitPhoneNumbers.GetById",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitPhoneNumberResponse(request.CorrelationId());

            var businessUnitPhoneNumber = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitPhoneNumber is null)
            {
                return NotFound();
            }

            response.BusinessUnitPhoneNumber = _mapper.Map<BusinessUnitPhoneNumberDto>(businessUnitPhoneNumber);

            return Ok(response);
        }
    }
}