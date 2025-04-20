﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.ValueObjects
{
    public record  FullName
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

    }
}
