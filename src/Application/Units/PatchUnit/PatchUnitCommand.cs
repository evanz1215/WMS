using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Units.PatchUnit
{
    public class PatchUnitCommand : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument<UnitForUpdateDto> PatchDocument { get; set; }
    }

    public class PatchUnitCommandHandler : IRequestHandler<PatchUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatchUnitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchUnitCommand command, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Unit.IsExistedByIdAsync(command.Id))
            {
                throw new KeyNotFoundException();
            }

            var unitFromRepo = await _unitOfWork.Unit.GetByIdAsync(command.Id);
            var unitToPatch = _mapper.Map<UnitForUpdateDto>(unitFromRepo);
            command.PatchDocument.ApplyTo(unitToPatch);
            _mapper.Map(unitToPatch, unitFromRepo);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}