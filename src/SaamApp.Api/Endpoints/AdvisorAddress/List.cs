using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorAddressRequest>.WithActionResult<
        ListAdvisorAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorAddress> _repository;

        public List(IRepository<AdvisorAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorAddresses")]
        [SwaggerOperation(
            Summary = "List AdvisorAddresses",
            Description = "List AdvisorAddresses",
            OperationId = "advisorAddresses.List",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorAddressResponse>> HandleAsync(
            [FromQuery] ListAdvisorAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorAddressResponse(request.CorrelationId());

            var spec = new AdvisorAddressGetListSpec();
            var advisorAddresses = await _repository.ListAsync(spec);
            if (advisorAddresses is null)
            {
                return NotFound();
            }

            response.AdvisorAddresses = _mapper.Map<List<AdvisorAddressDto>>(advisorAddresses);
            response.Count = response.AdvisorAddresses.Count;

            return Ok(response);
        }
    }
}