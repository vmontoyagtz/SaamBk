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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdInvoiceRequest>.WithActionResult<
        GetByIdInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Invoice> _repository;

        public GetByIdWithIncludes(
            IRepository<Invoice> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoices/i/{InvoiceId}")]
        [SwaggerOperation(
            Summary = "Get a Invoice by Id With Includes",
            Description = "Gets a Invoice by Id With Includes",
            OperationId = "invoices.GetByIdWithIncludes",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdInvoiceResponse>> HandleAsync(
            [FromRoute] GetByIdInvoiceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdInvoiceResponse(request.CorrelationId());

            var spec = new InvoiceByIdWithIncludesSpec(request.InvoiceId);

            var invoice = await _repository.FirstOrDefaultAsync(spec);


            if (invoice is null)
            {
                return NotFound();
            }

            response.Invoice = _mapper.Map<InvoiceDto>(invoice);

            return Ok(response);
        }
    }
}