using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gwent.FormModels
{
    public class NotificationModel
    {
        public int SenderUserId {get;set;}
        [DisplayName("Friends: ")]
        public int RecipientUserId { get;set; }
        public string Message { get; set; }
        [DisplayName("Message Type: ")]
        public NotificationType NotificationType { get; set; }
        public DateTimeOffset SentOn { get; set; }

        public List<User> Friends { get; set; }

        public SelectList FriendList
        {
            get
            {
                return new SelectList(Friends, "Id", "EmailAddress");
            }
        }

        public SelectList NotificationTypeList
        {
            get
            {
                var notificationTypes = Enum.GetNames(typeof(NotificationType));
                return new SelectList(notificationTypes);
            }
        }
        
        public void PopulateSelectLists(Context context)
        {
            FriendsRepository friendRepo = new FriendsRepository(context);
            NotificationsRepository notiRepo = new NotificationsRepository(context);
            Friends = friendRepo.GetFriendsById(SenderUserId);
        }
    }
}