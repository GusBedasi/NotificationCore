using NotificationEngine;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        // Creates a message
        var message = new NotificationMessage()
        {
            UserId = "123",
            Type = NotificationType.Welcome,
            Payload = new Payload()
            {
                CustomMessage = "Hello world!"
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
    }
}