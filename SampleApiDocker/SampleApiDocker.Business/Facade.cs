using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApiDocker.Business
{
    public sealed class Facade
    {
        private static readonly Facade instance = new Facade();

        private Facade()
        {
        }
        static Facade()
        {

        }

        public BaseBusiness<U> Factory<U>() where U : class
        {
            return new BaseBusiness<U>();
        }

        public T Factory<T, U>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static Facade Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
