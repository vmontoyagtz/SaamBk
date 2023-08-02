using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListInvoiceRequest>.WithActionResult<ListInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Invoice> _repository;

        public List(IRepository<Invoice> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoices")]
        [SwaggerOperation(
            Summary = "List Invoices",
            Description = "List Invoices",
            OperationId = "invoices.List",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<ListInvoiceResponse>> HandleAsync(
            [FromQuery] ListInvoiceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListInvoiceResponse(request.CorrelationId());

            var spec = new InvoiceGetListSpec();
            var invoices = await _repository.ListAsync(spec);
            if (invoices is null)
            {
                return NotFound();
            }

            response.Invoices = _mapper.Map<List<InvoiceDto>>(invoices);
            response.Count = response.Invoices.Count;

            return Ok(response);
        }
    }
}