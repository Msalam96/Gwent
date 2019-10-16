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

        public void StartGame (int playerOneId, int playerTwoId)
        {
            Game game = gameRepository.CreateGame(playerOneId, playerTwoId);

            Deck playerOneDeck = gameRepository.GetPlayerDeck(playerOneId);
            Deck playerTwoDeck = gameRepository.GetPlayerDeck(playerTwoId);

            Pile playerOneHand = gameRepository.CreateHand(game, playerOneDeck);
            Pile playerTwoHand = gameRepository.CreateHand(game, playerTwoDeck);

            GameRound currentRound = gameRepository.AddGameRound(game);
        }

        public void PlayCard (int pileCardId, Game myGame)
        {
            PileCard cardToPlay = gameRepository.GetPileCardById(pileCardId);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame)[0];
            gameRepository.MakeMove(cardToPlay, currentGameRound);
        }

        public void PassMove (int playerId, Game myGame)
        {
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame)[0];
            currentGameRound = gameRepository.PassTurn(currentGameRound, playerId);
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

        public GameState GetGameState(Game myGame)
        {
            return new GameState()
            {
                GameId = myGame.Id,
                RoundNumber = gameRepository.GetCurrentGameRounds(myGame).Count
            };
        }
    }
}
