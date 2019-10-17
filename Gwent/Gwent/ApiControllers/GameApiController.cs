using GwentSharedLibrary.Logic;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace Gwent.ApiControllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Gwent")]
    public class GameApiController : ApiController
    {
        private GameLogic gameLogic;
        private GameRepository gameRepository;

        public GameApiController() {
            gameLogic = new GameLogic(gameRepository);
        }

        [Route("newgame/{playerOneId}&{playerTwoId}")]
        async public Task<GameState> Post(int playerOneId, int playerTwoId)
        {
            gameLogic.StartGame(playerOneId, playerTwoId);
            return await gameLogic.GetGameState();
        }

    }
}