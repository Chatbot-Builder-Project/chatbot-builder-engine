using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Abstract.Messaging;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification;