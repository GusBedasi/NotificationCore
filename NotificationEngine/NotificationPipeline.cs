namespace NotificationEngine;

public class NotificationPipeline
{
    // Delegate to define a name for the handler instead of using Funcs
    public delegate Task HandlersDelegate(NotificationMessage message, Func<Task> next);
    
    // private field to store all handlers
    private readonly List<HandlersDelegate> _handlers = new();

    // Method to add new handlers
    public NotificationPipeline Use(HandlersDelegate handler)
    {
        _handlers.Add(handler);
        return this;
    }
    
    // Method that receives the message and pass it through all the pipeline
    public Func<NotificationMessage, Task> Build()
    {
        // Create a Func with a message which will be added later on the call of the return
        // of the method
        return message =>
        {
            return Handler(0);

            // Create an inner recursive method that will iterate through all handlers
            Task Handler(int index)
            {
                // Pretend that _handler.Count is 3
                // if index which start with 0 is equal to 3 does nothing
                // else call itself adding plus 1 to the 0 and so on so forth
                // till index is equal to 3
                // and every time it is not executes the handler with the given message
                return index == _handlers.Count
                    ? Task.CompletedTask 
                    : _handlers[index](message, () => Handler(index + 1));
            }
        };
    }
}