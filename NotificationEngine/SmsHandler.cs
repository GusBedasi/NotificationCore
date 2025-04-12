namespace NotificationEngine;

public class SmsHandler: INotifier
{
    public static Task SendAsync(NotificationMessage message, Func<Task> next)
    {
        Console.WriteLine($"Sending SMS with message: {message.Payload.CustomMessage}");
        return next();
    }
}