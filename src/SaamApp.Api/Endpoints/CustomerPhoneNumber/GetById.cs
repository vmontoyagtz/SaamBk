using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPhoneNumberEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerPhoneNumberRequest>.WithActionResult<
        GetByIdCustomerPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public GetById(
            IRepository<CustomerPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPhoneNumber by Id",
            Description = "Gets a CustomerPhoneNumber by Id",
            OperationId = "customerPhoneNumbers.GetById",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPhoneNumberResponse(request.CorrelationId());

            var customerPhoneNumber = await _repository.GetByIdAsync(request.RowId);
            if (customerPhoneNumber is null)
            {
                return NotFound();
            }

            response.CustomerPhoneNumber = _mapper.Map<CustomerPhoneNumberDto>(customerPhoneNumber);

            return Ok(response);
        }
    }
}