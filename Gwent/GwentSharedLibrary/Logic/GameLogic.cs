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
        public Game Game { get; private set; }

        public GameLogic(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public GameLogic(GameRepository gameRepository, int gameId) : this(gameRepository)
        {
            this.Game = gameRepository.GetGameById(gameId);
        }

        public void StartGame(int playerOneId, int playerTwoId)
        {
            Game game = new Game(playerOneId, playerTwoId);
            gameRepository.CreateGame(game);

            Deck playerOneDeck = gameRepository.GetPlayerDeck(playerOneId);
            Deck playerTwoDeck = gameRepository.GetPlayerDeck(playerTwoId);

            Pile playerOneHand = gameRepository.CreateHand(game.Id, playerOneDeck);
            Pile playerTwoHand = gameRepository.CreateHand(game.Id, playerTwoDeck);

            GameRound currentRound = gameRepository.AddGameRound(game);

            //Sets Active Player to PlayerOne
            currentRound.ActivePlayerId = playerOneId;
            gameRepository.UpdateGameRound(currentRound);

            Game = game;
        }

        public void PlayCard(int pileCardId)
        {
            //foreach(var pileCard in Game.Piles)
            PileCard cardToPlay = gameRepository.GetPileCardById(pileCardId);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(cardToPlay.Pile.GameId)[0];
            gameRepository.MakeMove(cardToPlay, currentGameRound);

            string playCardMessage = currentGameRound.ActivePlayer.FirstName + " played a " + cardToPlay.Card.CardType + " card";
            if (currentGameRound.ActivePlayerId == Game.PlayerOneId)
            {
                SendMessage(Game.PlayerTwoId, playCardMessage);
            }
            else
            {
                SendMessage(Game.PlayerOneId, playCardMessage);
            }          

            if (currentGameRound.ActivePlayerId == currentGameRound.FirstPlayerId && !currentGameRound.SecondPlayerPassed)
            {
                currentGameRound.ActivePlayerId = currentGameRound.SecondPlayerId;

                string message = "It's " + currentGameRound.SecondPlayer.FirstName + "'s turn";
                SendMessage(Game.PlayerOneId, message);
                SendMessage(Game.PlayerTwoId, message);
            }
            else if (currentGameRound.ActivePlayerId == currentGameRound.SecondPlayerId && !currentGameRound.FirstPlayerPassed)
            {
                currentGameRound.ActivePlayerId = currentGameRound.FirstPlayerId;

                string message = "It's " + currentGameRound.FirstPlayer.FirstName + "'s turn";
                SendMessage(Game.PlayerOneId, message);
                SendMessage(Game.PlayerTwoId, message);
            }
            gameRepository.UpdateGameRound(currentGameRound);
        }

        public void PassMove(int playerId)
        {
            Game myGame = gameRepository.GetGameById(Game.Id);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame.Id)[0];
            currentGameRound = gameRepository.PassTurn(currentGameRound, playerId);

            if (Game.PlayerOneId == playerId)
            {
                string message = Game.PlayerOne.FirstName + " has passed their turn.";
                SendMessage(Game.PlayerTwoId, message);
            }
            else if (Game.PlayerTwoId == playerId)
            {
                string message = Game.PlayerTwo.FirstName + " has passed their turn.";
                SendMessage(Game.PlayerOneId, message);            
            }

            if (HasRoundEnded(currentGameRound))
            {
                WhoWins(playerId);
            }
            else
            {
                string message = "It's " + currentGameRound.ActivePlayer.FirstName + "'s turn.";
                SendMessage(Game.PlayerOneId, message);
                SendMessage(Game.PlayerTwoId, message);
            }


        }

        public bool HasRoundEnded(GameRound currentRound)
        {
            //each time a player passes, this method is called
            return (currentRound.FirstPlayerPassed && currentRound.SecondPlayerPassed);
        }

        public void WhoWins(int playerId)
        {
            GameState gameState = GetGameState(playerId);
            List<GameRound> rounds = gameRepository.GetCurrentGameRounds(Game.Id);
            GameRound currentRound = rounds[0];
            var roundWinnerId = 0;
            //Each time round ends, this method is called
            
            foreach (var pile in Game.Piles)
            {
                gameRepository.MoveCardsToDiscardPile(pile);
            }

            //gameRepository.MoveCardsToDiscardPile();
            //gameRepository.MoveCardsToDiscardPile(player2hand);
            if (gameState.RoundState.Player1RoundState.Score > gameState.RoundState.Player2RoundState.Score)
            {
                currentRound.WinnerPlayerId = currentRound.FirstPlayerId;
                roundWinnerId = currentRound.FirstPlayerId;

                //Do I send this message to both players or just one player????
                string message = currentRound.FirstPlayer.FirstName + " has won the round.";
                SendMessage(currentRound.SecondPlayerId, message);
                SendMessage(currentRound.FirstPlayerId, message);
            }
            else if (gameState.RoundState.Player1RoundState.Score < gameState.RoundState.Player2RoundState.Score)
            {
                currentRound.WinnerPlayerId = currentRound.SecondPlayerId;
                roundWinnerId = currentRound.SecondPlayerId;

                //Do I send this message to both players or just one player????
                string message = currentRound.SecondPlayer.FirstName + " has won the round.";
                SendMessage(currentRound.SecondPlayerId, message);
                SendMessage(currentRound.FirstPlayerId, message);
            }
            //Equal scores?

            gameRepository.UpdateGameRound(currentRound);

            int playerOneWins = rounds.Where(r => r.WinnerPlayerId == Game.PlayerOneId).Count();
            int playerTwoWins = rounds.Where(r => r.WinnerPlayerId == Game.PlayerTwoId).Count();

            if (playerOneWins < 2 && playerTwoWins < 2)
            {
                currentRound = gameRepository.AddGameRound(Game);

                if (roundWinnerId != 0)
                {
                    currentRound.ActivePlayerId = roundWinnerId;
                }
                gameRepository.UpdateGameRound(currentRound);
            }
        }

        private List<PlayerHandState> PlayerStateHelper(int playerId)
        {
            Pile playerPile = gameRepository.GetPileByDeckId(gameRepository.GetPlayerDeck(playerId).Id);
            List<PileCard> playerPileCards = gameRepository.GetCardsInPile(playerPile);
            var playerPileInfo = new List<PlayerHandState>();

            foreach (var pileCard in playerPileCards)
            {
                if(pileCard.Location == Location.Hand)
                {
                    PlayerHandState playerHandState = new PlayerHandState()
                    {
                        PileCardId = pileCard.Id,
                        ImageUrl = pileCard.Card.ImageUrl
                    };
                    playerPileInfo.Add(playerHandState);
                }
            }
            return playerPileInfo;
        }

        //Helper function to get cards on board of type
        public List<BoardCardState> GetCardsOnBoard(CardType cardType, int playerId)
        {
            Pile playerPile = gameRepository.GetPileByDeckId(gameRepository.GetPlayerDeck(playerId).Id);
            List<PileCard> playerPileCards = gameRepository.GetCardsInPile(playerPile);
            var playerBoardInfo = new List<BoardCardState>();

            //int score = 0;

            foreach (var pileCard in playerPileCards)
            {
                if (pileCard.Card.CardType == cardType && pileCard.Location == Location.Board)
                {
                    //score += pileCard.Card.Strength.Value;
                    BoardCardState boardCardState = new BoardCardState();

                    boardCardState.PileCardId = pileCard.Id;
                    boardCardState.Image = pileCard.Card.ImageUrl;
                    boardCardState.SetScore(pileCard.Card.Strength.Value);

                    playerBoardInfo.Add(boardCardState);
                }
            }
            return playerBoardInfo;
        }

        public void SendMessage (int recepientUserId, string message)
        {
            gameRepository.AddGameMessage(Game.Id, message, recepientUserId);
        }

        public GameState GetGameState(int userId)
        {
            Game myGame = gameRepository.GetGameById(Game.Id);
            var rounds = gameRepository.GetCurrentGameRounds(Game.Id);
            var roundNumber = rounds.Count;
            var activePlayerId = rounds[0].ActivePlayerId.Value;

            var gameState = new GameState()
            {
                GameId = myGame.Id,
                RoundNumber = roundNumber,
                Player1State = new PlayerState()
                {
                    FirstName = myGame.PlayerOne.FirstName,
                    PlayerId = myGame.PlayerOne.Id,
                    RoundsWon = rounds.Where(r => r.WinnerPlayerId == myGame.PlayerOneId).Count(),
                    PlayerHandState = PlayerStateHelper(myGame.PlayerOneId)
                },
                Player2State = new PlayerState()
                {
                    FirstName = myGame.PlayerTwo.FirstName,
                    PlayerId = myGame.PlayerTwoId,
                    RoundsWon = rounds.Where(r => r.WinnerPlayerId == myGame.PlayerTwoId).Count(),
                    PlayerHandState = PlayerStateHelper(myGame.PlayerTwoId)
                },
                RoundState = new RoundState()
                {
                    GameRoundId = gameRepository.GetCurrentGameRounds(Game.Id)[0].Id,
                    Player1RoundState = new PlayerRoundState()
                    {
                        CloseCombat = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.CloseCombat, myGame.PlayerOneId),
                        },
                        Ranged = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.Ranged, myGame.PlayerOneId)
                        },
                        Siege = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.Seige, myGame.PlayerOneId)
                        },
                    },
                    Player2RoundState = new PlayerRoundState()
                    {
                        CloseCombat = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.CloseCombat, myGame.PlayerTwoId),
                        },
                        Ranged = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.Ranged, myGame.PlayerTwoId)
                        },
                        Siege = new CardTypeState()
                        {
                            BoardCardState = GetCardsOnBoard(CardType.Seige, myGame.PlayerTwoId)
                        },
                    },
                    ActivePlayerId = activePlayerId
                }
            };

            if (gameState.Winner != null)
            {
                // TODO winning messages
                string winnerMessage = gameState.Winner.PlayerName + " Has Won The Game. Congratulations!";
                string loserMessage = gameState.Winner.PlayerName + " Has Won The Game. Better luck next time!";

                if (gameState.Winner.PlayerId == myGame.PlayerOneId)
                {
                    SendMessage(myGame.PlayerOneId, winnerMessage);
                    SendMessage(myGame.PlayerTwoId, loserMessage);
                }
                else
                {
                    SendMessage(myGame.PlayerTwoId, winnerMessage);
                    SendMessage(myGame.PlayerOneId, loserMessage);
                }
            }

            var messages = gameRepository.getUndeliveredMessages(myGame.Id, userId);

            gameState.Messages = messages.Count > 0 ? messages.Select(m => m.Message).ToList() : null;

            return gameState;
        }
    }
}
