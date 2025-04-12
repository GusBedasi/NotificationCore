namespace NotificationEngine;

public class NotificationMessage
{
    public string UserId { get; set; }
    public NotificationType Type { get; set; }
    public Payload Payload { get; set; }
}

public enum NotificationType
{
    Welcome,
}

public class Payload
{
    public string CustomMessage { get; set; }
}