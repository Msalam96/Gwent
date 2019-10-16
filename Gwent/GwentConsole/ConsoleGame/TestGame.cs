using Gwent.Security;
using GwentSharedLibrary.Data;
using GwentSharedLibrary.Logic;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using Newtonsoft.Json;
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
        public void StartNewGame(int player1Id, int player2Id)
        {
            using (var context = new Context())
            {
                //int playerOneId = 1;
                //int playerTwoId = 2;
                //int winner = 0;
                //int loser = 0;

                //int player1Score = 0;
                //int player2Score = 0;
                GameState currentState = new GameState();

                GameRepository repository = new GameRepository(context);
                GameLogic gameLogic = new GameLogic(repository);
                currentState = gameLogic.StartGame(1, 2);
                Game game = repository.GetGame(1, 2);
                currentState = gameLogic.PlayCard(1, game);
                string json = JsonConvert.SerializeObject(currentState);
                Console.WriteLine(json);
                //Console.WriteLine(currentState.GameId.ToString() + " " + currentState.RoundNumber.ToString() + currentState.Player1State.FirstName + currentState.Player1State.PlayerId);
                Console.ReadKey();
                //Game myGame = repository.CreateGame(player1Id, player2Id);      //Creates the game with two players

                //Deck PlayerOneDeck = repository.GetPlayerDeck(player1Id);
                //Deck PlayerTwoDeck = repository.GetPlayerDeck(player2Id);

                //var PlayerOneCards = repository.DrawCards(PlayerOneDeck.Id, 10);
                //var PlayerTwoCards = repository.DrawCards(PlayerTwoDeck.Id, 10);

                //Pile playerOneHand = repository.CreateHand(myGame, PlayerOneDeck);
                //Pile playerTwoHand = repository.CreateHand(myGame, PlayerTwoDeck);

                //GameRound gameRound = repository.AddGameRound(myGame);
                //gameRound = repository.GetCurrentRound(myGame);

                //Console.WriteLine("First Game Round Id: " + gameRound.Id);

                //List<PileCard> pileCards1 = repository.GetCardsInHand(playerOneHand);
                //List<PileCard> pileCards2 = repository.GetCardsInHand(playerTwoHand);
                
                //repository.MakeMove(pileCards1[0], gameRound);
                //player1Score += pileCards1[0].Card.Strength.Value;
                //Console.Write("Player 1 score is " + player1Score);
                //repository.MakeMove(pileCards1[1], gameRound);



                //gameRound = repository.PassTurn(gameRound, player1Id);
                //Console.WriteLine("First player passed: " + gameRound.FirstPlayerPassed + " Second Player Passed: " + gameRound.SecondPlayerPassed);

                //gameRound = repository.PassTurn(gameRound, player2Id);
                //Console.WriteLine("First player passed: " + gameRound.FirstPlayerPassed + " Second Player Passed: " + gameRound.SecondPlayerPassed);

                //repository.MoveCardsToDiscardPile(playerOneHand);
                //repository.MoveCardsToDiscardPile(playerTwoHand);

                //if (gameRound.FirstPlayerPassed == true && gameRound.SecondPlayerPassed == true)
                //{
                //    Console.WriteLine("Next Round Begins");
                //}

                //gameRound = repository.AddGameRound(myGame);

                //Console.WriteLine("Second Game Round Id: " + gameRound.Id);
                ////return "DeckIdOne: " + PlayerOneDeck.Id + " NumberOfCards_PlayerOne: " + PlayerOneCards.Count;
                //Console.ReadKey();
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
