using System.Threading.Tasks;
using Api.Abstracts;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace Api.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectController : BasicCrudController<Project>
    {
        private readonly IProjectLogic _projectLogic;
        private readonly UserManager<User> _userManager;

        public ProjectController(IProjectLogic projectLogic, UserManager<User> userManager)
        {
            _projectLogic = projectLogic;
            _userManager = userManager;
        }
        
        protected override async Task<IBasicLogic<Project>> BasicLogic()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return _projectLogic.For(user);
        }
    }
}