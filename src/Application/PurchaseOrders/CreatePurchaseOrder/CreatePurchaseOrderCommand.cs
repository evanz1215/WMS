using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using Domain.PurchaseOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.CreatePurchaseOrder
{
    public class CreatePurchaseOrderCommand : IRequest<Guid>
    {
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        public Guid WarehouseId { get; set; }

        //[Required]
        //public int PurchaseOrderStatus { get; set; }

        [Required]
        public DateTime PurchaseOrderDate { get; set; }


        [MaxLength(100)]
        public string Description { get; set; }



        public virtual ICollection<PurchaseOrderLineFromPurchaseOrderForCreationDto> PurchaseOrderLine { get; set; }
    }


    public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePurchaseOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePurchaseOrderCommand command, CancellationToken cancellationToken)
        {


            var purchaseOrder = _mapper.Map<PurchaseOrder>(command);
            var result = await _unitOfWork.PurchaseOrder.CreateAsync(purchaseOrder);
            await _unitOfWork.SaveChangesAsync();

            return result.Entity.Id;

        }
    }
}
