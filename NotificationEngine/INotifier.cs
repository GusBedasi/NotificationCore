namespace NotificationEngine;

public interface INotifier
{
    static abstract Task SendAsync(NotificationMessage message, Func<Task> next);
}