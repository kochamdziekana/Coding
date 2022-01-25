using System;
using System.Collections.Generic;
using System.Linq;

namespace Adapter
{
    public class Program // pozwala na łączenie niekompatybilnych interfejsów, przyłączenie zewnętrznej części do wewnętrznej poprzez właśnie adapter, jak wtyczki w różnych gniazdkach
    {
        public static void Main(string[] args)
        {
            INotificationSender sender = new EmailSender();
            sender.SendNotification(1, new Notification()
            {
                Title = "Test",
                Body = "Body"
            });

            sender = new SmsSenderAdapter();
            sender.SendNotification(2, new Notification() { Title = "Test", Body = "Body" });
            
        }
    }
}