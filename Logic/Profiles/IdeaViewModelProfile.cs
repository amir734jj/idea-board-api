using AutoMapper;
using Logic.Interfaces;
using Logic.Profiles.Resolvers;
using Models;
using Models.ViewModels.Api;

namespace Logic.Profiles
{
    public class IdeaViewModelProfile : Profile
    {
        public IdeaViewModelProfile()
        {
            CreateMap<Idea, IdeaViewModel>()
                .ForMember(x => x.Categories, x => x.MapFrom<IdeaCategoryResolver>());

            CreateMap<IdeaViewModel, Idea>()
                .ForMember(x => x.IdeaCategoryRelationships, x => x.MapFrom<IdeaCategoryRelationshipResolver>());
        }
    }
}