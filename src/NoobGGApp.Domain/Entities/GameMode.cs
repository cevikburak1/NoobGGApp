using NoobGGApp.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class GameMode:EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public override string CreatedByUserId { get; set; } = "Burak";
        public override DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

    }
}
