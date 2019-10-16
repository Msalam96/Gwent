(async() =>{
    const gebi = (e) => document.getElementById(e);

    const notificationForm = gebi("notification-form");
    const notificationDiv = gebi("notifications");

    //const today = new Date();
    //const dd = String(today.getDate()).padStart(2, '0');
    //const mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    //const yyyy = today.getFullYear();

    //const lastMessageTime = mm + '-' + dd + '-' + yyyy;

    let lastMessageTime = new Date();
    lastMessageTime.setHours(lastMessageTime.getHours()-1);
    setInterval(async () => {
        const nextMessageTime =  new Date();
        console.log("Retrieving messages from: "+lastMessageTime);
        await getNotifications(lastMessageTime);
        lastMessageTime = nextMessageTime;
    }, 1000);
    
    async function getNotifications(from)
    {
        const url = "http://localhost:50710/api/notifications?from="+from.toISOString();;
        const response = await fetch(url, {
            credentials:"include",
        });
        const data = await response.json();
        renderNotifications(data);
    }

    function renderNotifications(notifications) {
        if(notifications.length===0)
        {
            return;
        }
        const notificationHtml = notifications.map((notification) => {
            //Id = n.Id,
            //SenderUserId = n.SenderUserId,
            //SenderEmailAddress = n.SenderUser.EmailAddress,
            //SenderName = $"{n.SenderUser.FirstName} {n.SenderUser.LastName}",
            //Message = n.Message,
            //SentOn = n.SentOn,
            //NotificationType = n.NotificationType
            return `
                <div>
                    <h4>${notification.SenderName}</h4>
                    <h4>${notification.Message}</h4>
                </div>
            `;
        });
        const html = notificationHtml.join("");

        notificationDiv.innerHTML = html+notificationDiv.innerHTML;
    }
    notificationForm.addEventListener('submit', async (event) => {
        event.preventDefault();
        console.log(event.target);
        const recipientUserId = event.target.RecipientUserId.value;
        const message = event.target.Message.value;
        const notificationType = event.target.NotificationType.value;
        console.log("Recipient Id:" + recipientUserId);
        console.log("Message: " + message);
        console.log("Notification Type: "+ notificationType);
        console.log(event);

        const data = {
            recipientUserId,
            message,
            notificationType
        };

        const response = await fetch("http://localhost:50710/api/notifications/", {
            method:"POST",
            credentials:"include",
            body: JSON.stringify(data),
            headers:{
                "Content-Type": "application/json"
            }
        });
        console.log(response)
    });
})();