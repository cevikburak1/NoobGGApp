﻿using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSID.Creator.NET;

namespace NoobGGApp.Domain.Entities
{
    public sealed class Game:EntityBase<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GameRegion> GameRegions { get; set; } = [];
    }
}
