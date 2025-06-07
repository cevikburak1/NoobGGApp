using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class LobbyMessage : EntityBase<long>
    {
        public long LobbyId { get; set; }
        public Lobby Lobby { get; set; }
        public long SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string Content { get; set; }

    }
}
