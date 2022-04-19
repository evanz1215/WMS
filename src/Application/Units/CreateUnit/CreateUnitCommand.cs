using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using Domain.Units;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.CreateUnit
{
    public class CreateUnitCommand : IRequest<int>
    {
        public string Name { get; set; }
    }


    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUnitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUnitCommand command, CancellationToken cancellationToken)
        {
            var unit = _mapper.Map<Domain.Units.Unit>(command);
            var result = await _unitOfWork.Unit.CreateAsync(unit);
            await _unitOfWork.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}
