(async () => {
    const baseUrl = 'http://localhost:50710/api/deck/';

    const gebi = (e) => document.getElementById(e);
    const p1closeCombatId = 'p1closeCombat';
    const p1rangedId = 'p1ranged';
    const p1sieged = 'p1sieged';

    const handDeck = [];

    console.log()
    function getId(event)
    {
        console.log(event);
    }

    async function getNewShuffledDeck() {
        return await fetch(baseUrl);
    }

    async function putCardInPile(deckId, pileName, num) {
        //let cardCodes = cards.map(card => card.Name + card.CardType ).join(',');

        return await fetch(baseUrl + deckId + '/piles/' + pileName + '/'+ num, {
            method:'PATCH'
        });
    }


    async function getCardFromPile(deckId, pileName)
    {
        return await fetch(baseUrl + deckId + '/piles/' + pileName + '/list', {
            method:'GET'
        })
    }

    const response = await getNewShuffledDeck();
    const data = await response.json()
    console.log("Data is")
    console.log(data);
    console.log("Deck Id is:" +data.DeckId)
    const cards = data.Cards;
    console.log("Cards is ");
    console.log(cards);

    let deckId = data.DeckId;
    let playerOnePile = [];
    let playerTwoPile = [];
    let siegedPile = [];
    let rangePile = [];
    let closeCombatPile = [];

    console.log(cards);

    
    const pilename = "playerOne";

    playerOnePile = cards.slice(5, 10);
    playerTwoPile = cards.slice(0, 5);

    console.log("Calling putcardsinpile")
    await putCardInPile(deckId, pilename, 10);
    const pile = await getCardFromPile(deckId, pilename)
    console.log("Pile is");
    const hand = await pile.json();
    console.log(hand);

    console.log("Card info is")
    console.log(hand.CardInfo)
    
    handDisplay = gebi("hand");

    //Gets all the available divs from the hands section
    slots = handDisplay.children;
 
    //loops through them all to check if an image is already placed
    for(let i = 0; i <slots.length; i++)
    {
        //handSlot is the nested image tag inside the parent div it's in

        handSlot = slots[i].children;

        //gets the current value of the dataset
        let isPlaced = handSlot[0].dataset.cardcode;
        console.log("isPlaced for slot "+ i )
        console.log(isPlaced)
        //Only adds the image src if it's an empty string
        console.log(isPlaced)
        if(isPlaced == "" || isPlaced == " ")
        {
            handSlot[0].src = hand.CardInfo[i].Image;
            handSlot[0].dataset.cardcode = (hand.CardInfo[i].Name + hand.CardInfo[i].CardType);
            console.log("data set is: ")
            console.log(handSlot[0].dataset.cardcode)
        }
       
    }
    //Gets the attributes for the selected image
    document.getElementById('hand')
        .addEventListener('click', async event => {
            const target = event.target;
    console.log("data code is: ")
    console.log(target.dataset.cardcode);
    console.log("Card style is: ")
    console.log(target.dataset.cardcode[target.dataset.cardcode.length-1])
    dataCode = target.dataset.cardcode;
    cardStyle = target.dataset.cardcode[target.dataset.cardcode.length-1];
    debugger; 
    switch(cardStyle)
    {
        case '0':
            let closeCombat = gebi("p2closeCombat");
            for(let i = 0; i <slots.length; i++)
            {
                handSlot = slots[i].children;
                let curr = handSlot[0].dataset.cardcode;
                if( curr == dataCode)
                {
                    for(let j = 0; j< closeCombat.children.length; j++)
                    {
                        let isPlaced = closeCombat.children[i].children[0].src;
                                 
                    }

                    console.log(closeCombat.children[0].children[0].src = handSlot[0].src)
                    handSlot[0].src = "";
                }
            }
            break;
        case '1':
            let ranged = gebi("p2ranged")
            for(let i = 0; i <slots.length; i++)
            {
                handSlot = slots[i].children;
                let curr = handSlot[0].dataset.cardcode;
                if( curr == dataCode)
                {
                    console.log(ranged.children[0].children[0].src = handSlot[0].src)
                    handSlot[0].src = "";
                }
            }
            break;
        case '2':
        case '3':
    }
            
});


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



