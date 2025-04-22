using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create
{
    public sealed record CreateGameRegionCommand(string Name,string Code,long GameId) :IRequest<long>
    {

    }
}
