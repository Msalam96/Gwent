(async() =>{
    const gebi = (e) => document.getElementById(e);

    const notificationForm = gebi("notification-form");

    notificationForm.addEventListener('submit', async (event) =>
    {
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