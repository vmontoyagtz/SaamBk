using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.EmployeePhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmployeePhoneNumberEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdEmployeePhoneNumberRequest>.WithActionResult<
        GetByIdEmployeePhoneNumberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeePhoneNumber> _repository;

        public GetById(
            IRepository<EmployeePhoneNumber> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/employeePhoneNumbers/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a EmployeePhoneNumber by Id",
            Description = "Gets a EmployeePhoneNumber by Id",
            OperationId = "employeePhoneNumbers.GetById",
            Tags = new[] { "EmployeePhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdEmployeePhoneNumberResponse>> HandleAsync(
            [FromRoute] GetByIdEmployeePhoneNumberRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdEmployeePhoneNumberResponse(request.CorrelationId());

            var employeePhoneNumber = await _repository.GetByIdAsync(request.RowId);
            if (employeePhoneNumber is null)
            {
                return NotFound();
            }

            response.EmployeePhoneNumber = _mapper.Map<EmployeePhoneNumberDto>(employeePhoneNumber);

            return Ok(response);
        }
    }
}