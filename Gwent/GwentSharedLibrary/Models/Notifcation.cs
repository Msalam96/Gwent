using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GwentSharedLibrary.Models
{
    public class Notification
    {
        public int Id { get; set; }
        
        public int SenderUserId { get; set; }
        public User SenderUser { get; set; }
       
        public int RecipientUserId { get; set; }
        public User RecipientUser { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTimeOffset SentOn { get; set; }

        public Notification(){}

        public Notification(int senderUserId, int recipientUserId, string message, NotificationType notificationType)
        {
            SenderUserId = senderUserId;
            RecipientUserId = recipientUserId;
            Message = message;
            NotificationType = notificationType;
            SentOn = DateTimeOffset.Now;
        }      
    }
}