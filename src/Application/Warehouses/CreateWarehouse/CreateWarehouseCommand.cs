using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using Domain.Warehouses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Warehouses.CreateWarehouse
{
    public class CreateWarehouseCommand : IRequest<Guid>
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int WarehouseTypeId { get; set; }
    }


    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWarehouseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateWarehouseCommand command, CancellationToken cancellationToken)
        {
            //TODO: 判斷是否重複

            var warehouse = _mapper.Map<Warehouse>(command);
            var result = await _unitOfWork.Warehouse.CreateAsync(warehouse);
            await _unitOfWork.SaveChangesAsync();

            return result.Entity.Id;

        }
    }
}
