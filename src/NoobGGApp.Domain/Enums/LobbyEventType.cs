using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Enums
{
    public enum LobbyEventType
    {
        LobbyCreated = 1,
        LobbyNameChanged = 2,
        LobbyClosed = 3,
        UserJoined = 4,
        UserLeft = 5,
        UserKicked = 6,
        UserBanned = 7,
        UserUnbanned = 8,
    }
}
