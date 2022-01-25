using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class SmsSenderAdapter : INotificationSender // adapter łączy klasę zewnętrzną z wewnętrznym interfejsem poprzez "klasę zastępczą"
    {
        private SmsSender _smsSender = new SmsSender();
        public void SendNotification(int userId, Notification notification)
        {
            string userPhoneNumber = null; // zależy od userId

            _smsSender.SendSms(userPhoneNumber, $"{notification.Title} {notification.Body}");
        }

    }
}
