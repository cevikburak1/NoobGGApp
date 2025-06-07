using NoobGGApp.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class Language : EntityBase<long>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<LobbyLanguage> LobbyLanguages { get; set; } = [];
    }
}
