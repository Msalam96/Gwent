using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GwentSharedLibrary.Repositories
{
    public class GameRepository
    {
        private Context context;

        public GameRepository(Context context)
        {
            this.context = context;
        }

        public Game CreateGame(int player1Id, int player2Id)
        {
            Game game = new Game(player1Id, player2Id);
            context.Games.Add(game);
            context.SaveChanges();
            return game;

            //AddGameRound(int gameId, int firstPlayerId, int secondPLayerId, false, false);
        }

        /*Game Controller Methods*/
            public string StartNewGame(int player1Id, int player2Id)
        {
            Game myGame= CreateGame(player1Id, player2Id);

            //GetGame(player1Id, player2Id);
            Deck PlayerOneDeck = GetPlayerDeck(player1Id);
            //Deck PlayerTwoDeck = GetPlayerDeck(player2Id);

            var PlayerOneCards = GetCards(PlayerOneDeck.Id);
            Pile hand = CreateHand(myGame, PlayerOneDeck);
            PileCard pileCard = context.PileCards
                                .Where(pc => pc.PileId == hand.Id)
                                .FirstOrDefault();
            GameRound gameRound = AddGameRound(myGame);
            MakeMove(pileCard, gameRound);
            PassTurn(gameRound, player1Id);

            return "DeckIdOne: " + PlayerOneDeck.Id + " NumberOfCards_PlayerOne: " + PlayerOneCards.Count ;

        }

        /* Game Controller Methods */

        public Game GetGame (int player1Id, int player2Id)
        {
            //Get their game from the DB
            Game myGame = context.Games
                            .Include(g => g.PlayerOne)
                            .Include(g => g.PlayerTwo)
                            .Where(g => g.PlayerOneId == player1Id && g.PlayerTwoId == player2Id)
                            .SingleOrDefault();

            return myGame;
        }

        public GameRound AddGameRound (Game game)
        {
            GameRound gameRound = new GameRound(0, game.Id, game.PlayerOneId, game.PlayerTwoId);
            context.GameRounds.Add(gameRound);
            context.SaveChanges();
            return gameRound;
        }


        //Get each player's deck
        public Deck GetPlayerDeck(int playerId)
        {
            //Deck deck = context.Decks
            //    .Include(d => d.DeckUsers.Select(du => du.User))
            //    .Select(d)
            //    .Where(d => d.DeckUsers.Select(du => du.User))
            //    .FirstOrDefault();

            DeckUser deckUsers = context.DeckUsers
                                    .Include(du=>du.Deck)
                                    .Where(du => du.UserId == playerId)
                                    .FirstOrDefault();


            return deckUsers.Deck;
        }
        //Get Card From Deck

        public List<Card> GetCards (int deckId)
        {
            List<Card> cardList = new List<Card>();
            List<DeckCard> deckCards = context.DeckCards
                                        .Include(dc => dc.Card)
                                        .Where(dc => dc.DeckId == deckId)
                                        .Take(1)            //change this to however many cards you need
                                        .ToList();

            foreach(var card in deckCards)
            {
                cardList.Add(card.Card);
            }
            return cardList;
        }

        //Create a Pile for each player

        public Pile CreateHand(Game myGame, Deck myDeck)
        {
            Pile hand = new Pile(0, myDeck.Id, myDeck, myGame.Id, myGame);

            List<Card> cardsList = GetCards(myDeck.Id);

            foreach (var card in cardsList)
            {
                PileCard pileCard = new PileCard()
                {
                    CardId = card.Id,
                    Card = card,
                    PileId = hand.Id,
                    Pile = hand,
                    Location = Location.Hand
                };
                context.PileCards.Add(pileCard);
                context.SaveChanges();
            }
            return hand;
        }

        //Make a move
        public void MakeMove(PileCard myHandCard, GameRound currentGameRound /*, User playerId*/)
        {
            myHandCard.Location = Location.Board;
            context.Entry(myHandCard).State = EntityState.Modified;

            //Update player's score

            GameRoundCard myGameRoundCard = new GameRoundCard()
            {
                GameRoundId = currentGameRound.Id,
                GameRound = currentGameRound,
                PileCard = myHandCard,
                PileCardId = myHandCard.Id
            };
            context.GameRoundCards.Add(myGameRoundCard);
            context.SaveChanges();

            //Move PileCard to correct spot (for corresponding player)
            //Update corresponding player's score
            //Update Location of card (remove from hand, move to board)
            
        }

        //Pass a turn
        public void PassTurn(GameRound myCurrentRound, int playerId)
        {
            if (myCurrentRound.FirstPlayerId == playerId)
            {
                myCurrentRound.FirstPlayerPassed = true;
            }
            else if (myCurrentRound.SecondPlayerId == playerId)
            {
                myCurrentRound.SecondPlayerPassed = true;
            }

            context.Entry(myCurrentRound).State = EntityState.Modified;
            context.SaveChanges();
        }

        //public void EndRound ()
    }
}
