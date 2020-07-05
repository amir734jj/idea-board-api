using System;
using EfCoreRepository.Interfaces;

namespace Models.Interfaces
{
    public interface IEntity : IEntity<int>
    {
        public static Type Amir { get; } 
    }
}