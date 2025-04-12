# 🔔 NotificationCore

A flexible and modern C# notification engine that supports sending messages through multiple channels (e.g., Email, SMS, Push) with support for extensible behaviors like **retry**, **fallback**, and **enrichment** — all composed elegantly via **static interface methods**, **delegates**, and **design patterns**.

---

## ✨ Features

- ✅ Multiple notification types (Email, SMS, etc.)
- 🧩 Pluggable `INotifier` implementations with `static abstract SendAsync`
- ⚡ Elegant use of **C# 11+ features** (`interface static abstract`)
- 🧪 Testable and composable behaviors
- 🔄 Recursive and delegate-based orchestration

---

## 🧠 How It Works

Notifications implement a static interface method:

```csharp
public interface INotifier
{
    static abstract Task SendAsync(NotificationMessage message, Func<Task> next);
}
````

Each notification type defines its own behavior:

````csharp
public class EmailNotification : INotifier
{
    public static Task SendAsync(NotificationMessage message, Func<Task> next)
    {
        // Pre processing
        // next();
        // Post processing
    }
}
````

The notification dispatcher invokes SendAsync generically:

```csharp
// Creates a message
var message = new NotificationMessage()
{
    UserId = "123",
    Type = NotificationType.Welcome,
    Payload = new Payload()
    {
        CustomMessage = "ABC"
    }
};

// Creates the pipeline
var pipeline = new NotificationPipeline();

// Add every handler with the interface static abstract method to avoid doing new()
pipeline
    .Use(LoggingHandler.SendAsync)
    .Use(EmailHandler.SendAsync)
    .Use(SmsHandler.SendAsync)
    // Build the pipeline with all required handler 
    // and execute passing the message (message)
    .Build()(message);
```

🙌 Credits
Made by @GusBedasi with a love for clean C# design and scalable backend systems.
