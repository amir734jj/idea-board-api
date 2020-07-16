using System.Linq;
using EfCoreRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Relationships;

namespace Dal.Profiles
{
    public class IdeaProfile : IEntityProfile<Idea, int>
    {
        private readonly IEntityProfileAuxiliary _entityProfileAuxiliary;

        public IdeaProfile(IEntityProfileAuxiliary entityProfileAuxiliary)
        {
            _entityProfileAuxiliary = entityProfileAuxiliary;
        }
        
        public Idea Update(Idea entity, Idea dto)
        {
            entity.Tag = dto.Tag;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.CreatedOn = dto.CreatedOn;
            entity.Votes = dto.Votes;
            entity.IdeaCategoryRelationships = _entityProfileAuxiliary.ModifyList<IdeaCategoryRelationship, int>(entity.IdeaCategoryRelationships, dto.IdeaCategoryRelationships);
            entity.Comments = _entityProfileAuxiliary.ModifyList<Comment, int>(entity.Comments, dto.Comments);

            return entity;
        }

        public IQueryable<Idea> Include<TQueryable>(TQueryable queryable) where TQueryable : IQueryable<Idea>
        {
            return queryable
                .Include(x => x.Votes)
                .Include(x => x.IdeaCategoryRelationships)
                .ThenInclude(x => x.Category)
                .Include(x => x.IdeaCategoryRelationships)
                .ThenInclude(x => x.Idea)
                .Include(x => x.Comments);
        }
    }
}