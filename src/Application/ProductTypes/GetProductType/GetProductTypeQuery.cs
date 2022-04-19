using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.GetProductType
{
    public class GetProductTypeQuery : IRequest<ProductTypeDto>
    {
        public int Id { get; set; }
    }


    public class GetProductTypeQueryHandler : IRequestHandler<GetProductTypeQuery, ProductTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetProductTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductTypeDto> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductType.GetByIdAsync(request.Id);
            var resultDto = _mapper.Map<ProductTypeDto>(result);

            return resultDto;
        }
    }
}
