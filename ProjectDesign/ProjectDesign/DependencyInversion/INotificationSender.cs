namespace DependencyInversion
{
    public interface INotificationSender
    {
        void SendNotification(User user);
    }
}