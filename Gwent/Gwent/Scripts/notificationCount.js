(async() =>{
    const gebi = (e) => document.getElementById(e);
    let notificationCount = localStorage.getItem("notifiCount");
    myStorage = window.localStorage;
    let lastMessageTime = new Date();
    setInterval(async () => {
        const nextMessageTime =  new Date();
        console.log("Retrieving messages from: "+lastMessageTime);
        await getNotifications(lastMessageTime);
        lastMessageTime = nextMessageTime;
        console.log("To Display " + notificationCount);
        countSpan.innerHTML = notificationCount;
          
    }, 1000);

    async function getNotifications(from)
    {
        const url = "http://localhost:50710/api/notifications?from="+from.toISOString();;
        const response = await fetch(url, {
            credentials:"include",
        });
        const data = await response.json();
        
        countSpan = gebi("totalNotifications");
        totCount = getCount(data);
        localStorage.setItem("notifiCount", totCount)

        console.log("STORED ITEM IS : " + localStorage.getItem("notifiCount"))

    }

    function getCount(notifications) {
        if(notifications.length===0)
        {
            return notificationCount;
        }
            return notificationCount++;
    };
   
})();