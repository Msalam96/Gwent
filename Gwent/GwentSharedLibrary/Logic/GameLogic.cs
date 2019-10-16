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

            Game = game;
        }

        public void PlayCard(int pileCardId)
        {
            //foreach(var pileCard in Game.Piles)
            PileCard cardToPlay = gameRepository.GetPileCardById(pileCardId);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(cardToPlay.Pile.GameId)[0];
            gameRepository.MakeMove(cardToPlay, currentGameRound);
        }

        public void PassMove(int playerId)
        {
            Game myGame = gameRepository.GetGameById(Game.Id);
            GameRound currentGameRound = gameRepository.GetCurrentGameRounds(myGame.Id)[0];
            currentGameRound = gameRepository.PassTurn(currentGameRound, playerId);

            if (HasRoundEnded(currentGameRound))
            {
                WhoWins();
            }
        }

        public bool HasRoundEnded(GameRound currentRound)
        {
            //each time a player passes, this method is called
            return (currentRound.FirstPlayerPassed && currentRound.SecondPlayerPassed);
        }

        public void WhoWins()
        {
            GameState gameState = GetGameState();
            List<GameRound> rounds = gameRepository.GetCurrentGameRounds(Game.Id);
            GameRound currentRound = rounds[0];

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
            }
            else if (gameState.RoundState.Player1RoundState.Score < gameState.RoundState.Player2RoundState.Score)
            {
                currentRound.WinnerPlayerId = currentRound.SecondPlayerId;
            }
            //Equal scores?

            gameRepository.UpdateGameRound(currentRound);

            int playerOneWins = rounds.Where(r => r.WinnerPlayerId == Game.PlayerOneId).Count();
            int playerTwoWins = rounds.Where(r => r.WinnerPlayerId == Game.PlayerTwoId).Count();

            if (playerOneWins < 2 && playerTwoWins < 2)
            {
                gameRepository.AddGameRound(Game);
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

        public GameState GetGameState()
        {
            Game myGame = gameRepository.GetGameById(Game.Id);
            var rounds = gameRepository.GetCurrentGameRounds(Game.Id);
            var roundNumber = rounds.Count;

            return new GameState()
            {
                GameId = myGame.Id,
                RoundNumber = roundNumber,
                Player1State = new PlayerState()
                {
                    FirstName = myGame.PlayerOne.FirstName,
                    PlayerId = myGame.PlayerOne.Id,
                    RoundsWon = rounds.Where(r => r.WinnerPlayerId == myGame.PlayerOneId).Count(), 
                    PlayerHandState = PlayerStateHelper(myGame.PlayerOneId)
                    //PlayerHandState = new Dictionary<string, PlayerHandState>(
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
                }
            };
        }
    }
}
