using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.Enums;

namespace Logic.Interfaces
{
    public interface IBoardLogic
    {
        Task<List<Idea>> Collect(int page, Sort sort, Order order);

        Task Vote(int ideaId, int userId, Vote vote);
    }
}