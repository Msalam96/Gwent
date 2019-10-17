using Gwent.Security;
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

        public GwentApiController(GameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [Route("NewGame/{player2Id}")]
        [HttpPost]
        public IHttpActionResult NewGame(int player2Id)
        {
            //User user = authRepo.GetByEmail(User.Identity.Name);
            //int player1Id = user.Id;

            CustomPrincipal user = (CustomPrincipal)User;
            int player1Id = user.User.Id;

            GameLogic gameLogic = new GameLogic(gameRepository);

            gameLogic.StartGame(player1Id, player2Id);
            return Ok(gameLogic.GetGameState(player1Id));
        }

        [Route("{gameId}/Play/{pileCardId}")]
        [HttpPost]
        public IHttpActionResult Play(int gameId, int pileCardId)
        {
            CustomPrincipal user = (CustomPrincipal)User;
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);

            gameLogic.PlayCard(pileCardId);
            return Ok(gameLogic.GetGameState(user.User.Id));
        }

        [Route("{gameId}/Pass")]
        [HttpPost]
        public IHttpActionResult Pass(int gameId)
        {
            CustomPrincipal user = (CustomPrincipal)User;
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);

            gameLogic.PassMove(user.User.Id);
            return Ok(gameLogic.GetGameState(user.User.Id));
        }

        [Route("{gameId}")]
        public IHttpActionResult Get(int gameId)
        {
            CustomPrincipal user = (CustomPrincipal)User;
            GameLogic gameLogic = new GameLogic(gameRepository, gameId);
            return Ok(gameLogic.GetGameState(user.User.Id));
        }
    }
}