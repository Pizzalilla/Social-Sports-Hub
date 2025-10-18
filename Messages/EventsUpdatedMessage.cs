using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Social_Sport_Hub.Messages
{
    public class EventsUpdatedMessage : ValueChangedMessage<bool>
    {
        public EventsUpdatedMessage() : base(true) { }
    }
}
