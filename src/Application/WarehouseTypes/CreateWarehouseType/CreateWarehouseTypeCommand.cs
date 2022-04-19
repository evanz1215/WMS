using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using Domain.WarehouseTypes;
using MediatR;

namespace Application.WarehouseTypes.CreateWarehouseType
{
    public class CreateWarehouseTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateWarehouseTypeCommandHandler : IRequestHandler<CreateWarehouseTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWarehouseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateWarehouseTypeCommand command, CancellationToken cancellationToken)
        {
            //TODO: 檢查是否重複
            var warehouse = _mapper.Map<WarehouseType>(command);
            var result = await _unitOfWork.WarehouseType.CreateAsync(warehouse);
            await _unitOfWork.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}