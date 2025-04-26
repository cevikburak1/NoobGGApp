using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetById
{
    public sealed record GameRegionGetByIdDto
    {
        long Id { get; set; }
        string Name { get; set; }   
        string Code { get; set; }
        long GameId { get; set; }

        public static GameRegionGetByIdDto Create(GameRegion gameRegion)
        {
            return new GameRegionGetByIdDto
            {
                Id = gameRegion.Id,
                Name = gameRegion.Name,
                Code = gameRegion.Code,
                GameId = gameRegion.GameId,
            };
        }
        public GameRegionGetByIdDto(long id,string name,string code,long gameId)
        {
            Id = id;
            Name = name;
            Code = code;
            GameId = gameId;
        }
        public GameRegionGetByIdDto()
        {
            
        }
    }
    
}
