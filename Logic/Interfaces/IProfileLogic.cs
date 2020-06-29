using System.Threading.Tasks;
using Models;
using Models.ViewModels.Api;

namespace Logic.Interfaces
{
    public interface IProfileLogic
    {
        Task Update(User user, ProfileViewModel profileViewModel);
    }
}