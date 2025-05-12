using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public sealed class CacheKeyPartAttribute :Attribute
    {
        public bool Encode { get; set; } = true;
        public string Prefix { get; set; } = string.Empty;
    }
}
