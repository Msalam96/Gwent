﻿(async() =>{
    const gebi = (e) => document.getElementById(e);

    const notificationForm = gebi("notification-form");
    const notificationDiv = gebi("notifications");

    const today = new Date();
    const dd = String(today.getDate()).padStart(2, '0');
    const mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    const yyyy = today.getFullYear();

    //const lastMessageTime = mm + '-' + dd + '-' + yyyy;

    const lastMessageTime = today.toISOString();

    console.log(lastMessageTime);
    console.log(today.getTimezoneOffset())
    
    async function getNotifications(from)
    {
        const url = "http://localhost:50710/api/notifications?from="+from;
        console.log(url);
        const response = await fetch(url, {
            credentials:"include",
        });
        console.log(response);
    }
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

    getNotifications(lastMessageTime);
})();