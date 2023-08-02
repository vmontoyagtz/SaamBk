using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdInvoiceRequest>.WithActionResult<
        GetByIdInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Invoice> _repository;

        public GetById(
            IRepository<Invoice> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoices/{InvoiceId}")]
        [SwaggerOperation(
            Summary = "Get a Invoice by Id",
            Description = "Gets a Invoice by Id",
            OperationId = "invoices.GetById",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdInvoiceResponse>> HandleAsync(
            [FromRoute] GetByIdInvoiceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdInvoiceResponse(request.CorrelationId());

            var invoice = await _repository.GetByIdAsync(request.InvoiceId);
            if (invoice is null)
            {
                return NotFound();
            }

            response.Invoice = _mapper.Map<InvoiceDto>(invoice);

            return Ok(response);
        }
    }
}