using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAiHistoryEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCustomerAiHistoryRequest>.WithActionResult<
        GetByIdCustomerAiHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAiHistory> _repository;

        public GetByIdWithIncludes(
            IRepository<CustomerAiHistory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAiHistories/i/{CustomerAiHistoryId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAiHistory by Id With Includes",
            Description = "Gets a CustomerAiHistory by Id With Includes",
            OperationId = "customerAiHistories.GetByIdWithIncludes",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAiHistoryResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerAiHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAiHistoryResponse(request.CorrelationId());

            var spec = new CustomerAiHistoryByIdWithIncludesSpec(request.CustomerAiHistoryId);

            var customerAiHistory = await _repository.FirstOrDefaultAsync(spec);


            if (customerAiHistory is null)
            {
                return NotFound();
            }

            response.CustomerAiHistory = _mapper.Map<CustomerAiHistoryDto>(customerAiHistory);

            return Ok(response);
        }
    }
}