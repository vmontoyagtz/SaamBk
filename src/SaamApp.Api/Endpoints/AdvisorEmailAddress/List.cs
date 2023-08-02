using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorEmailAddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorEmailAddressRequest>.WithActionResult<
        ListAdvisorEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public List(IRepository<AdvisorEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorEmailAddresses")]
        [SwaggerOperation(
            Summary = "List AdvisorEmailAddresses",
            Description = "List AdvisorEmailAddresses",
            OperationId = "advisorEmailAddresses.List",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorEmailAddressResponse>> HandleAsync(
            [FromQuery] ListAdvisorEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorEmailAddressResponse(request.CorrelationId());

            var spec = new AdvisorEmailAddressGetListSpec();
            var advisorEmailAddresses = await _repository.ListAsync(spec);
            if (advisorEmailAddresses is null)
            {
                return NotFound();
            }

            response.AdvisorEmailAddresses = _mapper.Map<List<AdvisorEmailAddressDto>>(advisorEmailAddresses);
            response.Count = response.AdvisorEmailAddresses.Count;

            return Ok(response);
        }
    }
}