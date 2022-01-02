namespace DependencyInversion
{
    public class EmailNotification
    {
        public void SendNotification(User user)
        {
            Console.WriteLine($"Sending notification to user : {user.Name}" );
        }

    }
}