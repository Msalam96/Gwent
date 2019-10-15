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
        }
    }
}