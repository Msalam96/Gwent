using GwentConsole.ConsoleGame;
using GwentSharedLibrary.Data;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DatabaseIntializer()); 
            using (var context = new Context())
            {
                GameRepository repository = new GameRepository(context);
                TestGame test = new TestGame();
                test.StartNewGame(1, 2);
                Console.ReadKey();
            }


            //GameApiController used to get begining state of the game
            //StartNewGame is a POST method where we create the Pile and Create a new game
            //This POST returns PlayerOneId and PlayerTwoId
            //Start the first round
            //Clicking a card generates a post
            //This POST also changes activePlayerId in GameRound
            //Changes the location of the PileCard and adds to GameRoundCard
            //The clicked card has a pilecardId
            //ActivePlayerId column in GameRound keeps track of who's the current player
            //Pass

            //GameLogic class with 3-4 methods, one being StartGame()
            //PlayCard()
            //
            //GetGameState(int GameId)
            //
        }
    }
}