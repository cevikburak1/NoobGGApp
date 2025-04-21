using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class Lobby : EntityBase<long>
    {
        public long GameId { get; private set; }
        public long GameModeId { get; private set; }
        public long GameRegionId { get; private set; }
        public long CreatorId { get; private set; }
        public static Lobby Create(long gameId, long gameModeId, long gameRegionId, long customerId)
        {
            var lobby = new Lobby()
            {
                GameId = gameId,
                GameModeId = gameModeId,
                GameRegionId = gameRegionId,
                CreatorId = customerId
            };
            lobby.RaiseDomainEvent(new LobbyCreatedDomainEvent(lobby));
            return lobby;
        }
      
    }
}