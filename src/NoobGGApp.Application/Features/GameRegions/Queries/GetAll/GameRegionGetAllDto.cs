using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Queries.GetAll
{
    public sealed record GameRegionGetAllDto
    {
        public long Id { get; set; }
        public string Name { get; set; }   
        public string Code { get; set; }
        public long GameId { get; set; }

        public static GameRegionGetAllDto Create(GameRegion gameRegion)
        {
            return new GameRegionGetAllDto
            {
                Id = gameRegion.Id,
                Name = gameRegion.Name,
                Code = gameRegion.Code,
                GameId = gameRegion.GameId,
            };
        }
        public GameRegionGetAllDto(long id,string name,string code,long gameId)
        {
            Id = id;
            Name = name;
            Code = code;
            GameId = gameId;
        }
        public GameRegionGetAllDto()
        {
            
        }
    }
}
