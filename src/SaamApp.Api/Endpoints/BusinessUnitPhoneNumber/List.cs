using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitPhoneNumberRequest>.WithActionResult<
        ListBusinessUnitPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitPhoneNumber> _repository;

        public List(IRepository<BusinessUnitPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitPhoneNumbers")]
        [SwaggerOperation(
            Summary = "List BusinessUnitPhoneNumbers",
            Description = "List BusinessUnitPhoneNumbers",
            OperationId = "businessUnitPhoneNumbers.List",
            Tags = new[] { "BusinessUnitPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitPhoneNumberResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitPhoneNumberResponse(request.CorrelationId());

            var spec = new BusinessUnitPhoneNumberGetListSpec();
            var businessUnitPhoneNumbers = await _repository.ListAsync(spec);
            if (businessUnitPhoneNumbers is null)
            {
                return NotFound();
            }

            response.BusinessUnitPhoneNumbers = _mapper.Map<List<BusinessUnitPhoneNumberDto>>(businessUnitPhoneNumbers);
            response.Count = response.BusinessUnitPhoneNumbers.Count;

            return Ok(response);
        }
    }
}