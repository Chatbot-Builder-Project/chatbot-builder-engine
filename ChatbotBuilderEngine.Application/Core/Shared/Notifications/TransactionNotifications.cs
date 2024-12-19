using MediatR;

namespace ChatbotBuilderEngine.Application.Core.Shared.Notifications;

public sealed class TransactionStartNotification : INotification;

public sealed class TransactionSuccessNotification : INotification;

public sealed class TransactionFailureNotification : INotification;

public sealed class TransactionCleanupNotification : INotification;