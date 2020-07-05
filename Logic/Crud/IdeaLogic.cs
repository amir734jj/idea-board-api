using EfCoreRepository.Interfaces;
using Logic.Abstracts;
using Logic.Interfaces;
using Models;

namespace Logic.Crud
{
    public class IdeaLogic : BasicLogicUserBoundAbstract<Idea>, IIdeaLogic
    {
        private readonly IBasicCrudType<Idea, int> _userDal;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="repository"></param>
        public IdeaLogic(IEfRepository repository)
        {
            _userDal = repository.For<Idea, int>();
        }

        /// <summary>
        /// Returns DAL
        /// </summary>
        /// <returns></returns>
        protected override IBasicCrudType<Idea, int> GetBasicCrudDal()
        {
            return _userDal;
        }
    }
}