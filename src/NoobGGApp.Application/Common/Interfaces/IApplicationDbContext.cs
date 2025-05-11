using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<GameRegion> GameRegions { get; set; }
        DbSet<Game> Games { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}
