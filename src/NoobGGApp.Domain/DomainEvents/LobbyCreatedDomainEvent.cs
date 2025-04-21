using NoobGGApp.Domain.Common.Events;
using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.DomainEvents
{
    public record  LobbyCreatedDomainEvent(Lobby Lobby) : IDomainEvent;
 
}
