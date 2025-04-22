using MediatR;
using Microsoft.Extensions.Logging;
using NoobGGApp.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Application.Features.GameRegions.Commands.Create
{
    public sealed class GameRegionCreatedDomainEventHandler : INotificationHandler<GameRegionCreatedDomainEvent>
    {
        private readonly ILogger<GameRegionCreatedDomainEventHandler> _logger;

        public GameRegionCreatedDomainEventHandler(ILogger<GameRegionCreatedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(GameRegionCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Game region created with ID: {GameRegionId}", notification.gameRegionId);
            throw new NotImplementedException();
        }
    }
}
