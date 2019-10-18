using Gwent.Security;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Gwent.ApiControllers
{
    [RoutePrefix("api/notifications")]
    [Authorize]
    public class NotificationsApiController : ApiController
    {
        private NotificationsRepository notificationsRepository;

        public NotificationsApiController(NotificationsRepository notificationsRepository)
        {
            this.notificationsRepository = notificationsRepository;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri]DateTimeOffset from)
        {
            CustomPrincipal user = (CustomPrincipal)User;
            List<Notification> notifications = notificationsRepository.GetNotificationsList(user.User.Id, from);
            var flattenedNotifications = notifications.Select(n => new
            {
                Id = n.Id,
                SenderUserId = n.SenderUserId,
                SenderEmailAddress = n.SenderUser.EmailAddress,
                SenderName = $"{n.SenderUser.FirstName} {n.SenderUser.LastName}",
                Message = n.Message,
                SentOn = n.SentOn,
                NotificationType = n.NotificationType.ToString(),
                NavigateToUrl = n.NavigateToUrl
            }).ToList();

            return Ok(flattenedNotifications);
        }
        
        public class NotificationPostRequest
        {
            public int RecipientUserId { get; set; }
            public string Message { get; set; }
            public NotificationType NotificationType { get; set; }
            public string NavigateToUrl { get; set; }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] NotificationPostRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomPrincipal user = (CustomPrincipal)User;
            Notification notification = new Notification(user.User.Id, request.RecipientUserId, 
                request.Message, request.NotificationType, request.NavigateToUrl);
            notificationsRepository.AddNotification(notification);

            //TODO need to create get for single notification
            return Created(" ", notification);
        }
    }
}