using MediatR;
using NoobGGApp.Application.Attributes;
using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById
{

    public sealed record  GetByIdGameRegionQuery(long Id) : IRequest<GameRegionGetByIdDto>
    {

    }
}
