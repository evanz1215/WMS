using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using Domain.ProductTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.CreateProductType
{
    public class CreateProductTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }


    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductTypeCommand command, CancellationToken cancellationToken)
        {
            //TODO: 檢查是否重複新增

            var productType = _mapper.Map<ProductType>(command);
            var result = await _unitOfWork.ProductType.CreateAsync(productType);
            await _unitOfWork.SaveChangesAsync();


            return result.Entity.Id;
        }
    }
}
