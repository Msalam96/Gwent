using GwentSharedLibrary.Logic;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gwent.ApiControllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Gwent")]
    [Authorize]
    public class GwentApiController : ApiController
    {
        private GameRepository gameRepository;
        private AuthenticationRepository authRepo;

        public GwentApiController(GameRepository gameRepository, AuthenticationRepository authRepo)
        {
            this.gameRepository = gameRepository;
            this.authRepo = authRepo;
        }

        [Route("NewGame/{player2Id}")]
        [HttpPost]
        public IHttpActionResult NewGame(int player2Id)
        {
            User user = authRepo.GetByEmail(User.Identity.Name);
            int player1Id = user.Id;
            GameLogic gameLogic = new GameLogic(gameRepository);

            gameLogic.StartGame(player1Id, player2Id);
            return Ok(gameLogic.GetGameState());
        }

        [Route("{gameId}/Play/{pileCardId}")]
        [HttpPost]
        public IHttpActionResult Play(int gameId, int pileCardId)
        {
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);

            gameLogic.PlayCard(pileCardId);
            return Ok(gameLogic.GetGameState());
        }

        [Route("{gameId}/Pass")]
        [HttpPost]
        public IHttpActionResult Pass(int gameId)
        {
            User user = authRepo.GetByEmail(User.Identity.Name);
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);

            gameLogic.PassMove(user.Id);
            return Ok(gameLogic.GetGameState());
        }

        [Route("{gameId}")]
        public IHttpActionResult Get(int gameId)
        {
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);
            return Ok(gameLogic.GetGameState());
        }
    }
}