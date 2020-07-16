using System.Linq;
using EfCoreRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dal.Profiles
{
    public class UserProfile : IEntityProfile<User, int>
    {
        public User Update(User entity, User dto)
        {
            entity.LastLoginTime = dto.LastLoginTime;

            return entity;
        }

        public IQueryable<User> Include<TQueryable>(TQueryable queryable) where TQueryable : IQueryable<User>
        {
            return queryable
                .Include(x => x.Votes)
                .Include(x => x.Comments)
                .Include(x => x.Ideas)
                .ThenInclude(x => x.IdeaCategoryRelationships);
        }
    }
}