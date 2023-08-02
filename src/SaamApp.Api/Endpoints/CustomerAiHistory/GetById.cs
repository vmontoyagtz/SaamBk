using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAiHistoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerAiHistoryRequest>.WithActionResult<
        GetByIdCustomerAiHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAiHistory> _repository;

        public GetById(
            IRepository<CustomerAiHistory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAiHistories/{CustomerAiHistoryId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAiHistory by Id",
            Description = "Gets a CustomerAiHistory by Id",
            OperationId = "customerAiHistories.GetById",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAiHistoryResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerAiHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAiHistoryResponse(request.CorrelationId());

            var customerAiHistory = await _repository.GetByIdAsync(request.CustomerAiHistoryId);
            if (customerAiHistory is null)
            {
                return NotFound();
            }

            response.CustomerAiHistory = _mapper.Map<CustomerAiHistoryDto>(customerAiHistory);

            return Ok(response);
        }
    }
}