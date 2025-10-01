namespace SocialSports.Maui.Utilities;

public static class EventBus
{
    public static event Action<Models.SportEvent>? EventCreated;

    public static void PublishEventCreated(Models.SportEvent e) => EventCreated?.Invoke(e);
}
