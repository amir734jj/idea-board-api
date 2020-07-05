using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Interfaces;
using Models;
using Models.Enums;

namespace Logic.Crud
{
    public class BoardLogic : IBoardLogic
    {
        private readonly IIdeaLogic _ideaLogic;

        public BoardLogic(IIdeaLogic ideaLogic)
        {
            _ideaLogic = ideaLogic;
        }
        
        public async Task<List<Idea>> Top()
        {
            var ideas = (await _ideaLogic.GetAll()).OrderByDescending(x => x.Votes).Take(50).ToList();

            return ideas;
        }

        public async Task<bool> Vote(int id, Vote vote)
        {
            switch (vote)
            {
                case Models.Enums.Vote.Up:
                    await _ideaLogic.Update(id, idea => idea.Votes++);
                    return true;
                case Models.Enums.Vote.Down:
                    await _ideaLogic.Update(id, idea => idea.Votes--);
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(vote), vote, null);
            }
        }
    }
}