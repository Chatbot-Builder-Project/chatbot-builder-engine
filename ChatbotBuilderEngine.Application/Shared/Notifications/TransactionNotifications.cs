using MediatR;

namespace ChatbotBuilderEngine.Application.Shared.Notifications;

public class TransactionStartNotification : INotification;

public class TransactionSuccessNotification : INotification;

public class TransactionFailureNotification : INotification;

public class TransactionCleanupNotification : INotification;