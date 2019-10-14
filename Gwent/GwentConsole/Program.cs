using GwentSharedLibrary.Data;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                GameRepository repository = new GameRepository(context);

                Console.Write(repository.StartNewGame(1, 2));
                Console.ReadKey();
            }
        }
    }
}
