using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPhoneNumberEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsCustomerPhoneNumberRequest>.WithActionResult<
        GetByIdCustomerPhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPhoneNumber> _repository;

        public GetByRelsIds(
            IRepository<CustomerPhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPhoneNumbers/{CustomerId}/{PhoneNumberId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPhoneNumber by rel Ids",
            Description = "Gets a CustomerPhoneNumber by rel Ids",
            OperationId = "customerPhoneNumbers.GetByRelsIds",
            Tags = new[] { "CustomerPhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsCustomerPhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPhoneNumberResponse(request.CorrelationId());

            var spec = new CustomerPhoneNumberByRelIdsSpec(request.CustomerId, request.PhoneNumberId);

            var customerPhoneNumber = await _repository.FirstOrDefaultAsync(spec);


            if (customerPhoneNumber is null)
            {
                return NotFound();
            }

            response.CustomerPhoneNumber = _mapper.Map<CustomerPhoneNumberDto>(customerPhoneNumber);

            return Ok(response);
        }
    }
}