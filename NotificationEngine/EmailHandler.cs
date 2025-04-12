namespace NotificationEngine;

public class EmailHandler : INotifier
{
    public static Task SendAsync(NotificationMessage message, Func<Task> next)
    {
        Console.WriteLine($"Sending Email with message: {message.Payload.CustomMessage}");
        return next();
    }
}