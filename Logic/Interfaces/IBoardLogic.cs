using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.Enums;

namespace Logic.Interfaces
{
    public interface IBoardLogic
    {
        Task<List<Idea>> Top();

        Task<bool> Vote(int id, Vote vote);
    }
}