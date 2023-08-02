using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerFeedbackEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerFeedbackRequest>.WithActionResult<
        ListCustomerFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerFeedback> _repository;

        public List(IRepository<CustomerFeedback> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerFeedbacks")]
        [SwaggerOperation(
            Summary = "List CustomerFeedbacks",
            Description = "List CustomerFeedbacks",
            OperationId = "customerFeedbacks.List",
            Tags = new[] { "CustomerFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerFeedbackResponse>> HandleAsync(
            [FromQuery] ListCustomerFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerFeedbackResponse(request.CorrelationId());

            var spec = new CustomerFeedbackGetListSpec();
            var customerFeedbacks = await _repository.ListAsync(spec);
            if (customerFeedbacks is null)
            {
                return NotFound();
            }

            response.CustomerFeedbacks = _mapper.Map<List<CustomerFeedbackDto>>(customerFeedbacks);
            response.Count = response.CustomerFeedbacks.Count;

            return Ok(response);
        }
    }
}