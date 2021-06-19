using System;

namespace SampleApiDocker.DataAccess
{
    public class FactoryDatabase<T> where T : class
    {
        public readonly Repository<T> Instance;
        public FactoryDatabase()
        {
            Instance = new Repository<T>();
        }
    }
}
