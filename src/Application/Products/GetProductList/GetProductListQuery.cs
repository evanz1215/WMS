using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.GetProductList
{
    public class GetProductListQuery : ListQueryModel<ProductListDto>
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int? ProductTypeId { get; set; }
        public bool? IsEnable { get; set; }
    }

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IListResponseModel<ProductListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IListResponseModel<ProductListDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Product.GetProjectedListDtoAsync(request);

            return result;
        }
    }
}
