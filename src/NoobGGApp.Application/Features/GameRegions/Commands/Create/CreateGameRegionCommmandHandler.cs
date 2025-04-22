using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create
{
    public sealed class CreateGameRegionCommmandHandler:IRequestHandler<CreateGameRegionCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateGameRegionCommmandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateGameRegionCommand request, CancellationToken cancellationToken)
        {
            var gameRegion = GameRegion.Create(request.Name, request.Code, request.GameId);
            _context.GameRegions.Add(gameRegion);
            await _context.SaveChangesAsync(cancellationToken);
            return gameRegion.Id;
        }
    }

}
