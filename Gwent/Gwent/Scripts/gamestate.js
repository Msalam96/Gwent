
(async() => {
   
    const gebi = (e) => document.getElementById(e);
    const handSlots = gebi("hand");
    const passButton = gebi("passButton");
    let currentTurn = true;

    async function getGameState(gameId) {
        const response = await fetch('http://localhost:50710/api/Gwent/' + gameId, {
            credentials:"include",
        });
        const data = await response.json();
        console.log(data);
        return data;
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

    async function acceptGameInvite(recipientUserId, gameId) {
        // Send a notification that the game invite was accepted
        const data = {
            recipientUserId,
            message: 'Waiting for you to join the game!',
            notificationType: 'AcceptedInvite',
            navigateToUrl: '/Gameboard/Index?GameId=' + gameId
        };

        await createNotification(data);
    }

    async function getNewGame(player2Id) {
        try {
            const response = await fetch('http://localhost:50710/api/Gwent/NewGame/' + player2Id, {
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
            const response = await fetch('http://localhost:50710/api/Gwent/' + gameId + '/Pass', {
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
            const response = await fetch('http://localhost:50710/api/Gwent/' + gameId + '/Play/'+pileCardId, {
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

    let gameState = null;
    let gameId = null;
    let intervalId = null;

    const urlParams = new URLSearchParams(window.location.search);

    if (urlParams.has('StartNewGame') && urlParams.has('Player2Id')) {
        const player2Id = urlParams.get('Player2Id');
        gameState = await getNewGame(player2Id);
        gameId = gameState.GameId;
        await acceptGameInvite(player2Id, gameId);
        location.href = `/Gameboard/Index?GameId=${gameId}`;
    } else if (urlParams.has('GameId')) {
        gameId = parseInt(urlParams.get('GameId'), 10);
        gameState = await getGameState(gameId);
    }

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
        }
        else{
            console.log("YOU CAN'T PASS ITS NOT YOUR TURN!")
        }
    });

    function renderGameboard(gameState) {
        if (gameState.Winner != null) {
            currentTurn = false;
            if (intervalId != null) {
                clearInterval(intervalId);
                intervalId = null;
            }
        } else {
            currentTurn = gameState.Player.IsActive;

            if (currentTurn) {
                if (intervalId != null) {
                    clearInterval(intervalId);
                    intervalId = null;
                }
            } else {
                if (intervalId == null) {
                    intervalId = setInterval(async () => {
                        renderGameboard(await getGameState(gameId));
                    }, 1000);
                }
            }
        }

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

        //Displaying opponent name
        const oppNameTag = gebi(oppName);
        const playerNametag = gebi(playerName);

        oppNameTag.innerText = gameState.PlayerOpponent.FirstName;
        playerNametag.innerText = gameState.Player.FirstName;
    
        //Displaying Opponenents number of cards
        const oppNumCardTag = gebi(oppNumCards);
        const playerNumCardTag = gebi(playerNumCards);

        //DisplayingOpponents number of rounds won
        oppRoundWonTag = gebi(oppRoundWon);
        playerRoundWonTag = gebi(playerRoundWon);

        oppNumCardTag.innerText = gameState.PlayerOpponent.Hand.length;
        playerNumCardTag.innerText = gameState.Player.Hand.length;

        oppRoundWonTag.innerText = gameState.PlayerOpponent.RoundsWon;
        playerRoundWonTag.innerText = gameState.Player.RoundsWon;

        oppTotalPowerTag = gebi(oppTotalPower);
        oppTotalPowerTag.innerText = gameState.Round.PlayerOpponent.Score;

        playerTotalPowerTag = gebi(playerTotalPower);
        playerTotalPowerTag.innerText = gameState.Round.Player.Score;

        const oppSiegeRowTag = gebi(oppSiegeRow);
        const oppRangeRowTag = gebi(oppRangedRow);
        const oppCloseCombatTag = gebi(oppCloseCombatRow);

        const playerSiegeRowTag = gebi(playerSiegeRow);
        const playerRangeRowTag = gebi(playerRangedRow);
        const playerCloseCombatTag = gebi(playerCloseCombatRow);

        const handTag = gebi(playerHand);
  
        const oppPlacedSiegeCards = gameState.Round.PlayerOpponent.Siege.Cards;
        const oppPlacedRangedCards = gameState.Round.PlayerOpponent.Range.Cards;
        const oppPlacedCloseCombatCards = gameState.Round.PlayerOpponent.CloseCombat.Cards;

        const playerPlacedSiegeCards = gameState.Round.Player.Siege.Cards;
        const playerPlacedRangedCards = gameState.Round.Player.Range.Cards;
        const playerPlacedCloseCombatCards = gameState.Round.Player.CloseCombat.Cards;

        const currentHand = gameState.Player.Hand;
    
        //<div class="col-md-2 col-sm-6 my-col">
        //                   <img src=""><img/>
        //                </div>
        //                <div class="col-md-2 col-sm-6 my-col">
        //                    Row 1 Col 3
        //                </div>

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
                <span>${gameState.Round.PlayerOpponent.CloseCombat.Score}</span>
            </div>
        `;
        const oppRangeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.PlayerOpponent.Range.Score}</span>
            </div>
        `;
       
        const oppSiegeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.PlayerOpponent.Siege.Score}</span>
            </div>
        `;

        const playerCloseCombatScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player.CloseCombat.Score}</span>
            </div>
        `;

        const playerRangeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player.Range.Score}</span>
            </div>
        `;

        const playerSiegeScore = `
            <div class="col-md-2 col-sm-6 my-col">
                <span>${gameState.Round.Player.Siege.Score}</span>
            </div>
        `;

        oppCloseCombatTag.innerHTML = oppCloseCombatScore + oppPlacedCloseCombatCards.map(renderCard).join('');
        oppRangeRowTag.innerHTML = oppRangeScore + oppPlacedRangedCards.map(renderCard).join('');
        oppSiegeRowTag.innerHTML = oppSiegeScore + oppPlacedSiegeCards.map(renderCard).join('');

        playerSiegeRowTag.innerHTML = playerSiegeScore + playerPlacedSiegeCards.map(renderCard).join('');
        playerRangeRowTag.innerHTML = playerRangeScore + playerPlacedRangedCards.map(renderCard).join('');
        playerCloseCombatTag.innerHTML = playerCloseCombatScore + playerPlacedCloseCombatCards.map(renderCard).join('');

        handTag.innerHTML = currentHand.map(renderCard).join('');

        const messagesTagId = 'messages';
        const messagesTag = gebi(messagesTagId);

        const messages = gameState.Messages;

        if (messages != null) {
            messages.reverse();
            const messagesHtml = messages.map((message) => {
                return `
                    <div>
                        <p>${message}</p>
                    </div>
                `;
            });
            messagesHtml.push('<div><p>------------------------</p></div>');
            messagesTag.innerHTML = messagesHtml.join('') + messagesTag.innerHTML;
        }
    }
})();
