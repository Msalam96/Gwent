
(async() => {
   
    const gebi = (e) => document.getElementById(e);
    const handSlots = gebi("hand");
    const passButton = gebi("passButton");
    let currentTurn = true;
    //async function getNewGame()
    //{
    //    return await fetch(baseUrl);
    //}

    async function getNewGame() {
        try {
            const response = await fetch('http://localhost:50710/api/Gwent/NewGame/2', {
                method:"POST",
                credentials:"include",
                headers:{
                    "Content-Type": "application/json"
                }
            });
            const data = await response.json();
            console.log(data);
            return data;
        } catch (error) {
            console.log(error);
        }
    }

    async function passMove(gameId)
    {
        try {
            const response = await fetch('http://localhost:50710/api/Gwent/'+ gameId+ '/Pass', {
                method:"POST",
                credentials:"include",
                headers:{
                    "Content-Type": "application/json"
                }
            });
            const data = await response.json();
            console.log(data);
            return data;
        } catch (error) {
            console.log('ERROR: '+error);
        }
    }
    async function playMove(gameId, pileCardId) {
        try {
            const response = await fetch('http://localhost:50710/api/Gwent/'+ gameId+ '/Play/'+pileCardId, {
                method:"POST",
                credentials:"include",
                headers:{
                    "Content-Type": "application/json"
                }
            });
            const data = await response.json();
            console.log(data);
            return data;
        } catch (error) {
            console.log('ERROR: '+error);
        }
    }

 

    const gameState = await getNewGame();
    const gameId = gameState.GameId;
    console.log(gameId);
    renderGameboard(gameState);

    
    handSlots.addEventListener('click', async (event) => {
        if(currentTurn)
        {
            const card = event.target;
            const pileCardId = card.getAttribute("Id");
            const nextState = await playMove(gameId, pileCardId)
            renderGameboard(nextState);
            console.log(nextState);
        }
        else{
            console.log("ITS NOT YOUR TURN!")
        }
    });

    passButton.addEventListener('click', async (event) => {
        if(currentTurn)
        {
            const nextState = await passMove(gameId)
            renderGameboard(nextState);
            console.log(nextState);
            currentTurn = !currentTurn;
        }
        else{
            console.log("YOU CAN'T PASS ITS NOT YOUR TURN!")
        }
    });

    function renderGameboard(gameState) {

        const oppName = "oppName";
        const playerName = "playerName"

        const playerGame = "playerGame";
        const oppNumCards = "numOppCard";
        const playerNumCards = "numPlayerCard";

        const playerRoundWon = "playerRoundWon";
        const oppRoundWon = "oppRoundWon";

        const oppTotalPower = "oppTotPower";
        const playerTotalPower = "playerTotPower";

        const playerHand = "hand";

        const oppSiegeRow = "p1sieged"
        const oppRangedRow = "p1ranged";
        const oppCloseCombatRow = "p1CloseCombat"

        const playerSiegeRow = "p2sieged";
        const playerRangedRow = "p2ranged";
        const playerCloseCombatRow = "p2CloseCombat"

        const hand = gebi(playerHand);

        //Displaying opponent name
        const oppNameTag = gebi(oppName);
        const playerNametag = gebi(playerName);

        oppNameTag.innerText = gameState.Player1.FirstName;
        playerNametag.innerText = gameState.Player2.FirstName;
    
        //Displaying Opponenents number of cards
        const oppNumCardTag = gebi(oppNumCards);
        const playerNumCardTag = gebi(playerNumCards);

        oppNumCardTag.innerText = gameState.Player1.Hand.length;
        playerNumCardTag.innerText = gameState.Player2.Hand.length;

        //DisplayingOpponents number of rounds won
        oppRoundWonTag = gebi(oppRoundWon);
        playerRoundWonTag = gebi(playerRoundWon);

        oppRoundWonTag.innerText = gameState.Player1.RoundsWon;
        playerRoundWonTag.innerText = gameState.Player2.RoundsWon;

        oppTotalPowerTag = gebi(oppTotalPower);
        oppTotalPowerTag.innerText = gameState.Round.Player1.Score;

        playerTotalPowerTag = gebi(playerTotalPower);
        playerTotalPowerTag.innerText = gameState.Round.Player2.Score;

        const oppSiegeRowTag = gebi(oppSiegeRow);
        const oppRangeRowTag = gebi(oppRangedRow);
        const oppCloseCombatTag = gebi(oppCloseCombatRow);

        const playerSiegeRowTag = gebi(playerSiegeRow);
        const playerRangeRowTag = gebi(playerRangedRow);
        const playerCloseCombatTag = gebi(playerCloseCombatRow);
        const handTag = gebi(playerHand);
  
        const oppPlacedSiegeCards = gameState.Round.Player1.Siege.Cards;
        const oppPlacedRangedCards = gameState.Round.Player1.Range.Cards;
        const oppPlacedCloseCombatCards = gameState.Round.Player1.CloseCombat.Cards;

        const playerPlacedSiegeCards = gameState.Round.Player2.Siege.Cards;
        const playerPlacedRangedCards = gameState.Round.Player2.Range.Cards;
        const playerPlacedCloseCombatCards = gameState.Round.Player2.CloseCombat.Cards;

        const currentHand = gameState.Player2.Hand;

    
        //<div class="col-md-2 col-sm-6 my-col">
        //                   <img src=""><img/>
        //                </div>
        //                <div class="col-md-2 col-sm-6 my-col">
        //                    Row 1 Col 3
        //                </div>

        console.log(oppPlacedSiegeCards);
    
        const renderCard = (card) => {
            return `
                <div class="col-md-2 col-sm-6 my-col">
                    <img id = "${card.PileCardId}" src="${card.ImageUrl}"/>
                </div>
            `;
        };

        //<div class="col-md-2 col-sm-6 my-col">
        //                <img id="s1" src="" data-cardCode="">
        //            </div>
        //            <div class="col-md-2 col-sm-6 my-col">
        //                <img id="s2" src="" data-cardCode="">
        //            </div>

        //            <div class="col-md-2 col-sm-6 my-col">
        //                <img id="s3" src="" data-cardCode="">
        //            </div>


        //Displaying all Sieged Cards for opponent for the round
        

        const oppCloseCombatScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player1.CloseCombat.Score}</span>
            </div>
        `;
        const oppRangeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player1.Range.Score}</span>
            </div>
        `;
       
        const oppSiegeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player1.Siege.Score}</span>
            </div>
        `;

        const playerCloseCombatScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player2.CloseCombat.Score}</span>
            </div>
        `;

        const playerRangeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player2.Range.Score}</span>
            </div>
        `;

        const playerSiegeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player2.Siege.Score}</span>
            </div>
        `;

        oppCloseCombatTag.innerHTML = oppCloseCombatScore + oppPlacedCloseCombatCards.map(renderCard).join('');
        oppRangeRowTag.innerHTML = oppRangeScore + oppPlacedRangedCards.map(renderCard).join('');
        oppSiegeRowTag.innerHTML = oppSiegeScore + oppPlacedSiegeCards.map(renderCard).join('');

        playerSiegeRowTag.innerHTML = playerSiegeScore + playerPlacedSiegeCards.map(renderCard).join('');
        playerRangeRowTag.innerHTML = playerRangeScore + playerPlacedRangedCards.map(renderCard).join('');
        playerCloseCombatTag.innerHTML = playerCloseCombatScore + playerPlacedCloseCombatCards.map(renderCard).join('');

        handTag.innerHTML = currentHand.map(renderCard).join('');

        //const data = [...];

        //const html = data.map((item) => {
        //    return `
        //        ${}
        //    `;
        //});
    }
})();








//const gameState = {
//    "GameId": 1,
//    "RoundNumber": 1,
//    "Player1": {
//        "FirstName": "Mo",
//        "PlayerId" : 1,
//        "RoundsWon": 0,
//        "Hand": [
//            {
//                "PileCardId": 1,
//                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//            },
//            {
//                "PileCardId": 2,
//                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//            }
//        ]
//    },
//    "Player2" : {
//        "FirstName" : "Sarthak",
//        "PlayerId" : 2,
//        "RoundsWon" : 0,
//        "Hand": [
//            {
//                "PileCardId": 2,
//                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//            }
//        ]
//    },
//    "Round": {
//        "GameRoundId": 1,
//        "Player1": {
//            "Score": 0,
//            "CloseCombat": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCardId" : 1,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    }
//                ]
//            },
//            "Range": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCard" : 2,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    }
//                ]
//            },
//            "Sieged": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCard" : 2,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    },  
//                    {
//                        "PileCard" : 2,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                     }
//                ]
//            },
//        },
//        "Player2": {
//            "Score": 0,
//            "CloseCombat": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCardId" : 1,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    }
//                ]
//            },
//            "Range": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCard" : 2,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    }
//                ]
//            },
//            "Sieged": {
//                "Score": 0,
//                "Cards": [
//                    {
//                        "PileCard" : 2,
//                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
//                    }
//                ]
//            },
//        },
//        "ActivePlayerId": 1,
//    },
//    "Winner": {
//        "PlayerId": null,
//        "PlayerName": null
//    } 
//};