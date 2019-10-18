
(async() => {
    const gebi = (e) => document.getElementById(e);

    const notificationForm = gebi("notification-form");
    const notificationDiv = gebi("notifications");

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
        console.log(data);
        renderNotifications(data);
    }

    function renderNotifications(notifications) {
        if(notifications.length===0)
        {
            return;
        }
        let notificationType = notifications.NotificationType;

        //switch(notificationType);
        const notificationHtml = notifications.map((notification) => {
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
                                    <td><a href="/Gameboard/Index?StartNewGame=True&Player2Id=${notification.SenderUserId}" class="btn btn-success">JOIN</a></td>
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
                                    <td><a href="${notification.NavigateToUrl}" class="btn btn-success">JOIN</a></td>
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

        event.target.Message.value = '';
    });
})();