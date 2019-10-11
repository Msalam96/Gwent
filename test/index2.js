(async () => {
    const baseUrl = 'http://localhost:50710/api/deck';

    const gebi = (e) => document.getElementById(e);
    const p1closeCombatId = 'p1closeCombat';
    const p1rangedId = 'p1ranged';
    const p1sieged = 'p1sieged';

    const handDeck = [];

    placeCard();

    console.log()
    function getId(event)
    {
      console.log(event);
    }
    response = await getNewShuffledDeck();
    console.log(response.json());
    async function getNewShuffledDeck() {
        return await fetch(baseUrl);
    }

    selectCard()
    {
        
    }
    function placeCard()
    {
        //returns HTMLCollection
        let row = gebi(p1rangedId);
        console.log("Row is: ");
        console.log(row);
        let cardSlots = row.children;

        for(let i = 0; i<cardSlots.length; i++)
        {
            
            // console.log("Column: " + i)
            // console.log(cardSlots[i]);
            // console.log("Children of Column " + i);
            // console.log(cardSlots[i].hasChildNodes());
            if(cardSlots[i].hasChildNodes===false)
            {
                cardSlots[i].innerHTML = "Card Placed";
            }
        }
    }
})();



