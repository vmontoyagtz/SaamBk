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
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAdvisorCustomerRequest>.WithActionResult<
        GetByIdAdvisorCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorCustomer> _repository;

        public GetByRelsIds(
            IRepository<AdvisorCustomer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorCustomers/{AdvisorId}/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorCustomer by rel Ids",
            Description = "Gets a AdvisorCustomer by rel Ids",
            OperationId = "advisorCustomers.GetByRelsIds",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorCustomerResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAdvisorCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorCustomerResponse(request.CorrelationId());

            var spec = new AdvisorCustomerByRelIdsSpec(request.AdvisorId, request.CustomerId);

            var advisorCustomer = await _repository.FirstOrDefaultAsync(spec);


            if (advisorCustomer is null)
            {
                return NotFound();
            }

            response.AdvisorCustomer = _mapper.Map<AdvisorCustomerDto>(advisorCustomer);

            return Ok(response);
        }
    }
}