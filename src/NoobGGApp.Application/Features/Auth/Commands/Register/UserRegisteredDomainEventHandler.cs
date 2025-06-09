﻿using System;
using MediatR;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Domain.DomainEvents;

namespace NoobGGApp.Application.Features.Auth.Commands.Register;


public sealed class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
{
    private readonly IMessagePublisher _messagePublisher;
    public UserRegisteredDomainEventHandler(IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
    }
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {

       

        var message = new UserRegisteredMessage(notification.Id, notification.Email, notification.FullName, "123456");

        await _messagePublisher.PublishUserRegisteredMessageAsync(message, cancellationToken);
    }
}



// public sealed class UserRegisteredDomainEventHandler : INotificationHandler<UserRegisteredDomainEvent>
// {
//     private readonly IMessageQueueService _messageQueueService;
//     public UserRegisteredDomainEventHandler(IMessageQueueService messageQueueService)
//     {
//         _messageQueueService = messageQueueService;
//     }
//     public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
//     {

//         

//         var message = new UserRegisteredMessage(notification.Id, notification.Email, notification.FullName, "123456");

//         await _messageQueueService.SendUserRegisteredMessageAsync(message, cancellationToken);
//     }
// }