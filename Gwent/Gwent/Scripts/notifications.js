
let notificationsApi = null;

(async() => {
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
        //console.log("Retrieving messages from: "+lastMessageTime);
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

    async function acceptGameInvite(recipientUserId) {
        // Send a notification that the game invite was accepted
        const data = {
            recipientUserId,
            message: 'Waiting for you to join the game!',
            notificationType: 'AcceptedInvite'
        };

        await createNotification(data);

        // Redirect the user to the game page
        location.href = '/Gameboard/Index';
    }

    function renderNotifications(notifications) {
        if(notifications.length===0)
        {
            return;
        }
        let notificationType = notifications.NotificationType;

        //switch(notificationType);
        const notificationHtml = notifications.map((notification) => {
            //Id = n.Id,
            //SenderUserId = n.SenderUserId,
            //SenderEmailAddress = n.SenderUser.EmailAddress,
            //SenderName = $"{n.SenderUser.FirstName} {n.SenderUser.LastName}",
            //Message = n.Message,
            //SentOn = n.SentOn,
            //NotificationType = n.NotificationType
            if (notification.NotificationType === 'Invite') {
                return `
                    <div>
                        <table>
                            <thead>
                                <tr>
                                    <th colspan ="2"> ${notification.SenderName}</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr> 
                                    <td>${notification.Message}</td>
                                    <td><a href="javascript:notificationsApi.acceptGameInvite(${notification.SenderUserId})" class="btn">JOIN</a></td>
                                </tr>
                            </tbody>
                        </table>                    
                    </div>
                `;
            } else if (notification.NotificationType === 'AcceptedInvite') {
                return `
                    <div>
                        <table>
                            <thead>
                                <tr>
                                    <th colspan ="2"> ${notification.SenderName}</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr> 
                                    <td>${notification.Message}</td>
                                    <td><a href="/GameBoard/Index" class="btn">JOIN</a></td>
                                </tr>
                            </tbody>
                        </table>                    
                    </div>
                `;
            } else {
                return `
                    <div>
                        <table>
                            <thead>
                                <tr>
                                    <th colspan ="2"> ${notification.SenderName}</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr> 
                                    <td>${notification.Message}</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>                    
                    </div>
                `;
            }
        });
        const html = notificationHtml.join("");

        notificationDiv.innerHTML = html+notificationDiv.innerHTML;
    }

    async function createNotification(data) {
        const response = await fetch("http://localhost:50710/api/notifications/", {
            method:"POST",
            credentials:"include",
            body: JSON.stringify(data),
            headers:{
                "Content-Type": "application/json"
            }
        });
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

        await createNotification(data);
    });

    return {
        acceptGameInvite
    };
})().then((api) => {
    notificationsApi = api;
});