using NoobGGApp.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class LobbyLanguage : EntityBase<long>
    {
        public long LobbyId { get; set; }
        public Lobby Lobby { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }

        // LobbyId = 1, LanguageId = 1 // Turkish
        // LobbyId = 1, LanguageId = 2 // English
    }
}
