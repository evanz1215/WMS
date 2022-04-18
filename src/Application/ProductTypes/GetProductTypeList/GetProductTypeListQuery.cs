using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using Domain.ProductTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.GetProductTypeList
{
    public class GetProductTypeListQuery : ListQueryModel<ProductTypeListDto>
    {
        public string Name { get; set; }
    }

    public class GetProductTypeListQueryHandler : IRequestHandler<GetProductTypeListQuery, IListResponseModel<ProductTypeListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductTypeListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IListResponseModel<ProductTypeListDto>> Handle(GetProductTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductType.GetProjectedListDtoAsync(
                request,
                additionalFilter: !string.IsNullOrWhiteSpace(request.Name) ? x => x.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase) : null,
                readOnly: true
                );

            return result;
        }
    }
}
