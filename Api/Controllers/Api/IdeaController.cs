using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Api.Abstracts;

namespace Api.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class IdeaController : BasicCrudController<Idea>
    {
        private readonly IIdeaLogic _ideaLogic;

        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="ideaLogic"></param>
        /// <param name="userManager"></param>
        public IdeaController(IIdeaLogic ideaLogic, UserManager<User> userManager)
        {
            _ideaLogic = ideaLogic;
            _userManager = userManager;
        }

        protected override async Task<IBasicLogic<Idea>> BasicLogic()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            return _ideaLogic.For(user);
        }
    }
}