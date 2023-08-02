using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceDetailEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdInvoiceDetailRequest>.WithActionResult<
        GetByIdInvoiceDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InvoiceDetail> _repository;

        public GetById(
            IRepository<InvoiceDetail> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/invoiceDetails/{InvoiceDetailId}")]
        [SwaggerOperation(
            Summary = "Get a InvoiceDetail by Id",
            Description = "Gets a InvoiceDetail by Id",
            OperationId = "invoiceDetails.GetById",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdInvoiceDetailResponse>> HandleAsync(
            [FromRoute] GetByIdInvoiceDetailRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdInvoiceDetailResponse(request.CorrelationId());

            var invoiceDetail = await _repository.GetByIdAsync(request.InvoiceDetailId);
            if (invoiceDetail is null)
            {
                return NotFound();
            }

            response.InvoiceDetail = _mapper.Map<InvoiceDetailDto>(invoiceDetail);

            return Ok(response);
        }
    }
}