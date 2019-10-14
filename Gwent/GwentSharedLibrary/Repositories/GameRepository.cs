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
            Deck PlayerTwoDeck = GetPlayerDeck(player2Id);
            //AddGameRound(myGame);

            return "DeckIdOne: " + PlayerOneDeck.Id + "DeckIdTwo: " + PlayerTwoDeck.Id;

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

        public void AddGameRound (Game game)
        {

            //GameRound gameRound = new GameRound();
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
        //Create a Pile for each player
    }
}
