using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.Enums;

namespace Api.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private readonly IBoardLogic _boardLogic;

        public BoardController(IBoardLogic boardLogic)
        {
            _boardLogic = boardLogic;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ideas = await _boardLogic.Top();

            return Ok(ideas);
        }
        
        [Authorize]
        [Route("{id}/{vote}")]
        [HttpGet]
        public async Task<IActionResult> Vote([FromRoute] int id, [FromRoute] Vote vote)
        {
            var result = await _boardLogic.Vote(id, vote);

            return Ok(result);
        }
    }
}