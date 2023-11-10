using Domain.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Shared
{
    public class BaseNotification : Notifiable<Notification>, IBaseNotification
    {
    }
}
