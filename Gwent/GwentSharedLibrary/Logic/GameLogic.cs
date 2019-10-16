using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Logic
{
    public class GameLogic
    {

        private GameRepository gameRepository;

        public GameLogic (GameRepository gameRepository) {
            this.gameRepository = gameRepository;
        }

        public GameState StartGame (int playerOneId, int playerTwoId)
        {
            Game game = gameRepository.CreateGame(playerOneId, playerTwoId);

            Deck playerOneDeck = gameRepository.GetPlayerDeck(playerOneId);
            Deck playerTwoDeck = gameRepository.GetPlayerDeck(playerTwoId);

            Pile playerOneHand = gameRepository.CreateHand(game, playerOneDeck);
            Pile playerTwoHand = gameRepository.CreateHand(game, playerTwoDeck);

            GameRound currentRound = gameRepository.AddGameRound(game);
            return GetGameState(game);
        }

        public GameState PlayCard (int pileCardId, Game myGame)
        {
            PileCard cardToPlay = gameRepository.GetPileCardById(pileCardId);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame)[0];
            gameRepository.MakeMove(cardToPlay, currentGameRound);
            return GetGameState(myGame);
        }

        public GameState PassMove (int playerId, Game myGame)
        {
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame)[0];
            currentGameRound = gameRepository.PassTurn(currentGameRound, playerId);
            return GetGameState(myGame);
        }

        private void CalculateScore()
        {
            //Each Time MakeMove is called, this method gets called
        }

        private bool HasRoundEnded (GameRound currentRound)
        {
            //each time a player passes, this method is called
            return (currentRound.FirstPlayerPassed && currentRound.SecondPlayerPassed);
        }

        private void WhoWon()
        {
            //Each time round ends, this method is called
        }

        //once both players have passed
        //use a private method to see who won
        //update roundswon in PlayerState
        private List<PlayerHandState> PlayerStateHelper(int playerId)
        {
            Pile playerPile = gameRepository.GetPileByDeckId(gameRepository.GetPlayerDeck(playerId).Id);
            List<PileCard> player1PileCards = gameRepository.GetCardsInPile(playerPile);
            var playerPileInfo = new List<PlayerHandState>();

            foreach (var pileCard in player1PileCards)
            {
                PlayerHandState playerHandState = new PlayerHandState()
                {
                    PileCardId = pileCard.Id,
                    ImageUrl = pileCard.Card.ImageUrl
                };
                playerPileInfo.Add(playerHandState);
            }
            return playerPileInfo;
        }

        public GameState GetGameState(Game myGame)
        {
            return new GameState()
            {
                GameId = myGame.Id,
                RoundNumber = gameRepository.GetCurrentGameRounds(myGame).Count,
                Player1State = new PlayerState()
                {
                    FirstName = myGame.PlayerOne.FirstName,
                    PlayerId = myGame.PlayerOne.Id,
                    PlayerHandState = PlayerStateHelper(myGame.PlayerOneId)
                    //PlayerHandState = new Dictionary<string, PlayerHandState>(
                },
                Player2State = new PlayerState()
                {
                    FirstName = myGame.PlayerTwo.FirstName,
                    PlayerId = myGame.PlayerTwoId,
                    PlayerHandState = PlayerStateHelper(myGame.PlayerTwoId)
                }
            };
        }
    }
}
