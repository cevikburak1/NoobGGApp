using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Common.Entities
{
    public interface IModifiedByEntity
    {
        string? ModifiedByUserId { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
