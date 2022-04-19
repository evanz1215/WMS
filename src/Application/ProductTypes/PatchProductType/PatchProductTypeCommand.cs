using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.PatchProductType
{
    public class PatchProductTypeCommand : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument<ProductTypeForUpdateDto> PatchDocument { get; set; }
    }


    public class PatchProductTypeCommandHandler : IRequestHandler<PatchProductTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatchProductTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchProductTypeCommand command, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.ProductType.IsExistedByIdAsync(command.Id))
            {
                throw new KeyNotFoundException();
            }

            var productTypeFromRepo = await _unitOfWork.ProductType.GetByIdAsync(command.Id);
            var productTypeToPatch = _mapper.Map<ProductTypeForUpdateDto>(productTypeFromRepo);
            command.PatchDocument.ApplyTo(productTypeToPatch);

            _mapper.Map(productTypeToPatch, productTypeFromRepo);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
