namespace NotificationEngine;

public class LoggingHandler : INotifier
{
    public static Task SendAsync(NotificationMessage message, Func<Task> next)
    {
        Console.WriteLine($"Logging message: {message.Payload.CustomMessage}");
        return next();
    }
}