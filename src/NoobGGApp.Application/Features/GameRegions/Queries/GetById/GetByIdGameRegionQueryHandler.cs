using MediatR;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById
{
    public sealed class GetByIdGameRegionQueryHandler : IRequestHandler<GetByIdGameRegionQuery, GameRegionGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdGameRegionQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<GameRegionGetByIdDto> Handle(GetByIdGameRegionQuery request, CancellationToken cancellationToken)
        {
           var gameRegion= await _applicationDbContext
                .GameRegions
                .AsNoTracking()
                .Include(x=>x.Game)
                .FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);

            return GameRegionGetByIdDto.Create(gameRegion!);
        }
    }
   
}
