using NoobGGApp.Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Common.Entities
{
    public abstract class EntityBase<TKey> : IEntity<TKey>, ICreatedByEntity, IModifiedByEntity where TKey : struct
    {
        public virtual TKey Id { get; set; }
        public virtual string CreatedByUserId { get; set; }
        public virtual DateTimeOffset CreatedOn { get; set; }
        public virtual string? ModifiedByUserId { get; set; }
        public virtual DateTimeOffset? ModifiedOn { get; set; }

        private readonly List<IDomainEvent> _domainEvents = [];
        protected IReadOnlyList<IDomainEvent> GetDomainEvents => _domainEvents.AsReadOnly();
        protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        protected void ClearDomainEvent() => _domainEvents.Clear();
        
    }
}
