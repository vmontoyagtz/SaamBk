using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AdvisorCustomerEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAdvisorCustomerRequest>.WithActionResult<
        GetByIdAdvisorCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AdvisorCustomer> _repository;

        public GetById(
            IRepository<AdvisorCustomer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/advisorCustomers/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AdvisorCustomer by Id",
            Description = "Gets a AdvisorCustomer by Id",
            OperationId = "advisorCustomers.GetById",
            Tags = new[] { "AdvisorCustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAdvisorCustomerResponse>> HandleAsync(
            [FromRoute] GetByIdAdvisorCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAdvisorCustomerResponse(request.CorrelationId());

            var advisorCustomer = await _repository.GetByIdAsync(request.RowId);
            if (advisorCustomer is null)
            {
                return NotFound();
            }

            response.AdvisorCustomer = _mapper.Map<AdvisorCustomerDto>(advisorCustomer);

            return Ok(response);
        }
    }
}