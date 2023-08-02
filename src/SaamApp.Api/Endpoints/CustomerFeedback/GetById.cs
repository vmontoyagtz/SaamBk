using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerFeedbackEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerFeedbackRequest>.WithActionResult<
        GetByIdCustomerFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerFeedback> _repository;

        public GetById(
            IRepository<CustomerFeedback> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerFeedbacks/{FeedbackId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerFeedback by Id",
            Description = "Gets a CustomerFeedback by Id",
            OperationId = "customerFeedbacks.GetById",
            Tags = new[] { "CustomerFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerFeedbackResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerFeedbackResponse(request.CorrelationId());

            var customerFeedback = await _repository.GetByIdAsync(request.FeedbackId);
            if (customerFeedback is null)
            {
                return NotFound();
            }

            response.CustomerFeedback = _mapper.Map<CustomerFeedbackDto>(customerFeedback);

            return Ok(response);
        }
    }
}