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
        private const int PageSize = 10;
        
        private readonly IIdeaLogic _ideaLogic;
        
        private readonly IUserLogic _userLogic;

        public BoardLogic(IIdeaLogic ideaLogic, IUserLogic userLogic)
        {
            _ideaLogic = ideaLogic;
            _userLogic = userLogic;
        }
        
        public async Task<List<Idea>> Collect(int pageNumber, Sort sort, Order order)
        {
            var ideas = await _ideaLogic.GetAll();
            
            return ideas
                .Skip(PageSize * pageNumber)
                .Take(PageSize)
                .ToList();
        }

        public async Task Vote(int ideaId, int userId, Vote vote)
        {
            await _userLogic.Update(userId, user =>
            {
                var previousVote = user.Votes.FirstOrDefault(y => y.Idea.Id == ideaId);

                if (previousVote == null)
                {
                    user.Votes.Add(new UserVote { IdeaId = ideaId, UserId = userId, Value = vote });
                }
                else
                {
                    previousVote.Value = vote;
                }
            });
        }
    }
}