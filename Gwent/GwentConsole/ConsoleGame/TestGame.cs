using Gwent.Security;
using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentConsole.ConsoleGame
{
    public class TestGame
    {
        /*Game Controller Methods*/
        public string StartNewGame(int player1Id, int player2Id)
        {
            using (var context = new Context())
            {
                GameRepository repository = new GameRepository(context);
                Game myGame = repository.CreateGame(player1Id, player2Id);      //Creates the game with two players

                Deck PlayerOneDeck = repository.GetPlayerDeck(player1Id);
                //Deck PlayerTwoDeck = GetPlayerDeck(player2Id);

                var PlayerOneCards = repository.DrawCards(PlayerOneDeck.Id, 10);
                Pile hand = repository.CreateHand(myGame, PlayerOneDeck);
                GameRound gameRound = repository.AddGameRound(myGame);
                gameRound = repository.GetCurrentRound(myGame);

                List<PileCard> pileCards = repository.GetCardsInHand(hand);
                
                repository.MakeMove(pileCards[0], gameRound);
                repository.MakeMove(pileCards[1], gameRound);



                repository.PassTurn(gameRound, player1Id);
                repository.MoveCardsToDiscardPile(hand);

                return "DeckIdOne: " + PlayerOneDeck.Id + " NumberOfCards_PlayerOne: " + PlayerOneCards.Count;
            }
        }

        /* Game Controller Methods */


        //Create a game
        //Insert to GameRound
        //Add a row to game
        //Get each player's deck
        //Create a pile for each player
        //Populate PileCard with 10 Cards from their respective Deck



        /*
         * Player 1 starts first (whoever sends request)
         * Api Populates Deck of 22 cards
         * Api Shuffles Cards
         * Top 10 cards are added to pile (hand)
         *  
         * Player 1 makes a move (play a card or pass)
         * Player 2 makes a movie (play a card or pass)
         * 
         * 
         * */
    }
}
