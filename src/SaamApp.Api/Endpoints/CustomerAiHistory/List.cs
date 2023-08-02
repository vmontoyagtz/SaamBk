using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCustomerAiHistoryRequest>.WithActionResult<
        ListCustomerAiHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAiHistory> _repository;

        public List(IRepository<CustomerAiHistory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAiHistories")]
        [SwaggerOperation(
            Summary = "List CustomerAiHistories",
            Description = "List CustomerAiHistories",
            OperationId = "customerAiHistories.List",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerAiHistoryResponse>> HandleAsync(
            [FromQuery] ListCustomerAiHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerAiHistoryResponse(request.CorrelationId());

            var spec = new CustomerAiHistoryGetListSpec();
            var customerAiHistories = await _repository.ListAsync(spec);
            if (customerAiHistories is null)
            {
                return NotFound();
            }

            response.CustomerAiHistories = _mapper.Map<List<CustomerAiHistoryDto>>(customerAiHistories);
            response.Count = response.CustomerAiHistories.Count;

            return Ok(response);
        }
    }
}