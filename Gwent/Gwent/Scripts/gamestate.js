const gebi = (e) => document.getElementById(e);
const gameState = {
    "GameId": 1,
    "RoundNumber": 1,
    "Player1": {
        "FirstName": "Mo",
        "PlayerId" : 1,
        "RoundsWon": 0,
        "Hand": [
            {
                "PileCardId": 1,
                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
            },
            {
                "PileCardId": 2,
                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
            }
        ]
    },
    "Player2" : {
        "FirstName" : "Sarthak",
        "PlayerId" : 2,
        "RoundsWon" : 0,
        "Hand": [
            {
                "PileCardId": 2,
                "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
            }
        ]
    },
    "Round": {
        "GameRoundId": 1,
        "Player1": {
            "Score": 0,
            "CloseCombat": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCardId" : 1,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    }
                ]
            },
            "Range": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCard" : 2,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    }
                ]
            },
            "Sieged": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCard" : 2,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    },  
                    {
                        "PileCard" : 2,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                     }
                ]
            },
        },
        "Player2": {
            "Score": 0,
            "CloseCombat": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCardId" : 1,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    }
                ]
            },
            "Range": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCard" : 2,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    }
                ]
            },
            "Sieged": {
                "Score": 0,
                "Cards": [
                    {
                        "PileCard" : 2,
                        "ImageUrl": "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg"
                    }
                ]
            },
        },
        "ActivePlayerId": 1,
    },
    "Winner": {
        "PlayerId": null,
        "PlayerName": null
    } 
};

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
  
    const oppPlacedSiegeCards = gameState.Round.Player1.Sieged.Cards;
    const oppPlacedRangedCards = gameState.Round.Player1.Range.Cards;
    const oppPlacedCloseCombatCards = gameState.Round.Player1.CloseCombat.Cards;

    const playerPlacedSiegeCards = gameState.Round.Player2.Sieged.Cards;
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
                <img src="${card.ImageUrl}"/>
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
    oppSiegeRowTag.innerHTML += oppPlacedSiegeCards.map(renderCard).join('');
    oppRangeRowTag.innerHTML += oppPlacedRangedCards.map(renderCard).join('');
    oppCloseCombatTag.innerHTML += oppPlacedCloseCombatCards.map(renderCard).join('');

    playerSiegeRowTag.innerHTML += playerPlacedSiegeCards.map(renderCard).join('');
    playerRangeRowTag.innerHTML += playerPlacedRangedCards.map(renderCard).join('');
    playerCloseCombatTag.innerHTML += playerPlacedCloseCombatCards.map(renderCard).join('');

    handTag.innerHTML += currentHand.map(renderCard).join('');

    //const data = [...];

    //const html = data.map((item) => {
    //    return `
    //        ${}
    //    `;
    //});





}

renderGameboard(gameState);
