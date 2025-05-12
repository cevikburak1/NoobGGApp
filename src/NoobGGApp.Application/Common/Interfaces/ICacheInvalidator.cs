using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Common.Interfaces
{
    public interface ICacheInvalidator
    {
        Task InvalidateAsync(string cacheKey, CancellationToken cancellationToken);
        Task InvalidateGroupAsync(string cacheGroup, CancellationToken cancellationToken);
    }
}
