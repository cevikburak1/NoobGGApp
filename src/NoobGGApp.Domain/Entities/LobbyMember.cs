using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public class LobbyMember : EntityBase<long>
    {
        public long LobbyId { get; set; }
        public Lobby Lobby { get; set; }

        public long UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsAdmin { get; set; }
    }
}
