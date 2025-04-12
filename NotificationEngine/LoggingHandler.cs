namespace NotificationEngine;

public class LoggingHandler : INotifier
{
    public static Task SendAsync(NotificationMessage message, Func<Task> next)
    {
        // Do something
        if (message.Payload.CustomMessage == "debug")
        {       
            Console.WriteLine($"Logging message: {message.Payload.CustomMessage}");
            return Task.CompletedTask;
        }

        Console.WriteLine($"Logging message: {message.Payload.CustomMessage}");
        
        // Call the next handler
        next();
        
        // Do something after the other handler
        return Task.CompletedTask;
    }
}