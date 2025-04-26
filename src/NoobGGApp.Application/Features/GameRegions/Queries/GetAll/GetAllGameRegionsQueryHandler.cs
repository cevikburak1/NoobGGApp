using MediatR;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll
{
    public sealed record GetAllGameRegionsQueryHandler : IRequestHandler<GetAllGameRegionsQuery, List<GameRegionGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetAllGameRegionsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Task<List<GameRegionGetAllDto>> Handle(GetAllGameRegionsQuery request, CancellationToken cancellationToken)
        {
            var query = _applicationDbContext
                 .GameRegions
                 .AsQueryable();

              if (request.GameId.HasValue)
                 query = query.Where(x => x.GameId == request.GameId);
              
              if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

              if (!string.IsNullOrEmpty(request.Code))
                query = query.Where(x => x.Code.ToLower().Contains(request.Code.ToLower()));

              return query
                .AsNoTracking()
                .Select(x => GameRegionGetAllDto.Create(x))
                .ToListAsync(cancellationToken);
        }

        //public  Task<List<GameRegionGetAllDto>> Handle(GetAllGameRegionsQuery request, CancellationToken cancellationToken)
        //{
        //    return _applicationDbContext
        //       .GameRegions
        //       .AsNoTracking()
        //       .Where(x => x.GameId == request.GameId)
        //       .Select(x=>GameRegionGetAllDto.Create(x))
        //       .ToListAsync(cancellationToken);
        //}
    }
}
   

