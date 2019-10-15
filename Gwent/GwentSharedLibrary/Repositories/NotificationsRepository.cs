using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace GwentSharedLibrary.Repositories
{
    public class NotificationsRepository
    {
        private Context context;
        
        public NotificationsRepository(Context context)
        {
            this.context = context;
        }

        public List<Notification> GetNotificationsList(int id, DateTimeOffset from)
        {
            return context.Notifications
                    .Include(n => n.SenderUser)
                    .Where(n => n.RecipientUserId == id && n.SentOn>=from)
                    .OrderByDescending(n => n.SentOn)
                    .ToList();
        }

        public void AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);
            context.SaveChanges();
        }
    }
}
