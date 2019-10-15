using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Repositories
{
    public class NotificationsRepository
    {
        private Context context;
        
        public NotificationsRepository(Context context)
        {
            this.context = context;
        }
        //public List<Notification> GetNotificationsList(int id)
        //{
        //    return context.Notifications
        //            .Where(ur => ur.SenderUserId == id)
        //            .ToList();
        //}
    }
}
