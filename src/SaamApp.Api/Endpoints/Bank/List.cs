using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBankRequest>.WithActionResult<ListBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Bank> _repository;

        public List(IRepository<Bank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/banks")]
        [SwaggerOperation(
            Summary = "List Banks",
            Description = "List Banks",
            OperationId = "banks.List",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<ListBankResponse>> HandleAsync([FromQuery] ListBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBankResponse(request.CorrelationId());

            var spec = new BankGetListSpec();
            var banks = await _repository.ListAsync(spec);
            if (banks is null)
            {
                return NotFound();
            }

            response.Banks = _mapper.Map<List<BankDto>>(banks);
            response.Count = response.Banks.Count;

            return Ok(response);
        }
    }
}