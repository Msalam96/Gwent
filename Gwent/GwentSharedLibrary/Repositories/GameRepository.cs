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

        public GameRound GetCurrentRound (Game game)
        {
            return context.GameRounds
                    .Include(gr => gr.Game)
                    .Include(gr => gr.FirstPlayer)
                    .Include(gr => gr.SecondPlayer)
                    .OrderByDescending(gr => gr.Id)
                    .Where(gr => gr.Id == game.Id)
                    .FirstOrDefault();
        }

        public List<GameRound> GetCurrentGameRounds (Game game)
        {
            return context.GameRounds
                    .Include(gr => gr.Game)
                    .Include(gr => gr.FirstPlayer)
                    .Include(gr => gr.SecondPlayer)
                    .OrderByDescending(gr => gr.Id)
                    .Where(gr => gr.Id == game.Id)
                    .ToList();
        }

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

        public List<Card> DrawCards (int deckId, int numberOfCards)            //Draws card from deck, sets IsDrawn property for card = true
        {
            List<Card> cardList = new List<Card>();
            List<DeckCard> deckCards = context.DeckCards
                                        .Include(dc => dc.Card)
                                        .Where(dc => dc.DeckId == deckId || dc.IsDrawn==false)
                                        .Take(numberOfCards)            //change this to however many cards you need
                                        .ToList();

            foreach(var card in deckCards)
            {
                cardList.Add(card.Card);
                card.IsDrawn = true;
                context.Entry(card).State = EntityState.Modified;
                context.SaveChanges();
            }
            return cardList;
        }

        //public Card DrawOneCard (int deckId)
        //{
        //    DeckCard deckCard = context.DeckCards
        //                        .Include(dc => dc.Card)
        //                        .Where(dc => dc.DeckId == deckId || dc.IsDrawn == false)
        //                        .FirstOrDefault();
        //    return deckCard.Card;
        //}

        public Pile CreateHand(Game myGame, Deck myDeck)            //Creates Pile (hand) and adds PileCards to that Pile
        {
            Pile hand = new Pile(0, myDeck.Id, myDeck, myGame.Id, myGame);

            List<Card> cardsList = DrawCards(myDeck.Id, 10);

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

        public List<PileCard> GetCardsInPile (Pile hand)
        {
            return context.PileCards
                    .Include(pc => pc.Card)
                    .Include(pc => pc.Pile)
                    .Where(pc => pc.PileId == hand.Id)
                    .ToList();

        }

        public List<PileCard> GetCardsInHand(Pile hand)         //returns list of cards currently in hand
        {
            return context.PileCards
                    .Include(pc => pc.Card)
                    .Include(pc => pc.Pile)
                    .Where(pc => pc.PileId == hand.Id && pc.Location == Location.Hand)
                    .ToList();

        }

        public PileCard GetPileCardByCardId (int cardId)        //Returns PileCard based on cardId
        {
            return context.PileCards
                    .Include(pc => pc.Card)
                    .Include(pc => pc.Pile)
                    .Where(pc => pc.CardId == cardId)
                    .FirstOrDefault();
        }

        public PileCard GetPileCardById (int pileCardId)
        {
            return context.PileCards
                    .Include(pc => pc.Card)
                    .Include(pc => pc.Pile)
                    .Where(pc => pc.Id == pileCardId)
                    .FirstOrDefault();
        }

        public void MakeMove(PileCard myHandCard, GameRound currentGameRound)
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

        public GameRound PassTurn(GameRound myCurrentRound, int playerId)
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
            return myCurrentRound;
        }

        public void MoveCardsToDiscardPile(Pile hand)
        {
            List<PileCard> pileCards = GetCardsInPile(hand);
            foreach(var pileCard in pileCards)
            {
                if(pileCard.Location == Location.Board)
                {
                    pileCard.Location = Location.Discard;
                    context.Entry(pileCard).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}
