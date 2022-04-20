using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.PatchPurchaseOrder
{
    public class PatchPurchaseOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public JsonPatchDocument<PurchaseOrderForUpdateDto> PatchDocument { get; set; }
    }


    public class PatchPurchaseOrderCommandHandler : IRequestHandler<PatchPurchaseOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatchPurchaseOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchPurchaseOrderCommand command, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.PurchaseOrder.IsExistedByIdAsync(command.Id))
            {
                throw new KeyNotFoundException();
            }

            var purchaseOrderFromRepo = await _unitOfWork.PurchaseOrder.GetByIdAsync(command.Id);
            var purchaseOrderToPatch = _mapper.Map<PurchaseOrderForUpdateDto>(purchaseOrderFromRepo);
            command.PatchDocument.ApplyTo(purchaseOrderToPatch);
            _mapper.Map(purchaseOrderToPatch, purchaseOrderFromRepo);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
