using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorCustomerEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAdvisorCustomerRequest>.WithActionResult<
        ListAdvisorCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorCustomer> _repository;

        public List(IRepository<AdvisorCustomer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorCustomers")]
        [SwaggerOperation(
            Summary = "List AdvisorCustomers",
            Description = "List AdvisorCustomers",
            OperationId = "advisorCustomers.List",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<ListAdvisorCustomerResponse>> HandleAsync(
            [FromQuery] ListAdvisorCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAdvisorCustomerResponse(request.CorrelationId());

            var spec = new AdvisorCustomerGetListSpec();
            var advisorCustomers = await _repository.ListAsync(spec);
            if (advisorCustomers is null)
            {
                return NotFound();
            }

            response.AdvisorCustomers = _mapper.Map<List<AdvisorCustomerDto>>(advisorCustomers);
            response.Count = response.AdvisorCustomers.Count;

            return Ok(response);
        }
    }
}