using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceDetailEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListInvoiceDetailRequest>.WithActionResult<
        ListInvoiceDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InvoiceDetail> _repository;

        public List(IRepository<InvoiceDetail> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoiceDetails")]
        [SwaggerOperation(
            Summary = "List InvoiceDetails",
            Description = "List InvoiceDetails",
            OperationId = "invoiceDetails.List",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<ListInvoiceDetailResponse>> HandleAsync(
            [FromQuery] ListInvoiceDetailRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListInvoiceDetailResponse(request.CorrelationId());

            var spec = new InvoiceDetailGetListSpec();
            var invoiceDetails = await _repository.ListAsync(spec);
            if (invoiceDetails is null)
            {
                return NotFound();
            }

            response.InvoiceDetails = _mapper.Map<List<InvoiceDetailDto>>(invoiceDetails);
            response.Count = response.InvoiceDetails.Count;

            return Ok(response);
        }
    }
}