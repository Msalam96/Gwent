(async() =>{
    const gebi = (e) => document.getElementById(e);
    const countSpan = gebi("totalNotifications");

    const notificationCountString = localStorage.getItem("notifiCount");
    let notificationCount = parseInt(notificationCountString, 10);
    if (isNaN(notificationCount)) {
        notificationCount = 0;
    }

    let lastMessageTime = new Date();
    setInterval(async () => {
        const nextMessageTime =  new Date();
        console.log("Retrieving messages from: "+lastMessageTime);
        const notifications = await getNotifications(lastMessageTime);
        lastMessageTime = nextMessageTime;

        notificationCount += notifications.length;
        localStorage.setItem("notifiCount", notificationCount);

        console.log("STORED ITEM IS : " + localStorage.getItem("notifiCount"))

        countSpan.innerHTML = notificationCount;          
    }, 1000);

    async function getNotifications(from)
    {
        const url = "http://localhost:50710/api/notifications?from="+from.toISOString();;
        const response = await fetch(url, {
            credentials:"include",
        });
        const data = await response.json();        
        return data;
    }
})();