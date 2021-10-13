using System;
using System.Collections.Generic;

namespace WpfTask10.Util
{
    public class DependencyInjector
    {
        public static readonly DependencyInjector instance = new DependencyInjector();

        private Dictionary<Type, object> dependencies;

        public T GetDependency<T>() where T : class
        {
            Type key = typeof(T);
            return dependencies.TryGetValue(key, out object value) ? (T)value : null;
        }

        public void Register<T>() where T : class, new()
        {
            Type key = typeof(T);

            if (dependencies.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            dependencies.Add(key, new T());
        }

        public void Register<TInt, TImpl>() where TInt : class where TImpl : class, new()
        {
            Type key1 = typeof(TInt);
            Type key2 = typeof(TImpl);

            if (dependencies.ContainsKey(key1))
            {
                throw new ArgumentException();
            }

            TImpl obj = new();
            dependencies.Add(key1, obj);

            if (!dependencies.ContainsKey(key2))
            {
                dependencies.Add(key2, obj);
            }
        }

        private DependencyInjector()
        {
            dependencies = new Dictionary<Type, object>();
        }
    }
}
