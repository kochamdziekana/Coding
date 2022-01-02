using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class AuthenticationManager
    {
        private INotificationSender _notificationSender;
     
        public AuthenticationManager(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void Authenicate(User user, string email, string password)
        {
            if(user.Email == email && user.Password == password)
            {
                _notificationSender.SendNotification(user);
            }   // emailNotification to moduł niskopoziomowy, a Authenticate wysokopoziomowy, który jest zależny od emailNotification
        }
    }
}
