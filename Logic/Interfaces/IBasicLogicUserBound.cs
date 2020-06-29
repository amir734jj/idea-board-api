using Models;
using Models.Interfaces;

namespace Logic.Interfaces
{
    public interface IBasicLogicUserBound<T> : IBasicLogic<T> where T: IEntity
    {
        public IBasicLogic<T> For(User user);
    }
}