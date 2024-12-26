using ChatbotBuilderEngine.Domain.Core.Abstract;
using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;