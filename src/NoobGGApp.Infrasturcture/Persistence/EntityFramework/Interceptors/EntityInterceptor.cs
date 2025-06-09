using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Interceptors
{
    public class EntityInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;

        public EntityInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditableEntity(eventData.Context);
            return result;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntity(eventData.Context);
            return new ValueTask<InterceptionResult<int>>(result);
        }
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            UpdateAuditableEntity(eventData.Context);
            return result;
        }
        private void UpdateAuditableEntity(DbContext? context)
        {
            if (context is null)
                return;

            var creatByEntries = context.ChangeTracker.Entries<ICreatedByEntity>()
                .Where(e => e.State is EntityState.Added);
            foreach (var entry in creatByEntries)
            {
                entry.Entity.CreatedByUserId = _currentUserService.UserId.HasValue ? _currentUserService.UserId.Value.ToString() : null;

                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            var modifiedByEntries = context.ChangeTracker.Entries<IModifiedByEntity>()
                .Where(e => e.State is EntityState.Modified);
            foreach (var entry in modifiedByEntries)
            {
                entry.Entity.ModifiedByUserId = _currentUserService.UserId.HasValue ? _currentUserService.UserId.Value.ToString() : null;

                entry.Entity.ModifiedOn = DateTime.UtcNow;
            }
        }

    }
}


