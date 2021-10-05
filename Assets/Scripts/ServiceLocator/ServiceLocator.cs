using System;
using System.Collections.Generic;

namespace Snake
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> ServiceContainer = 
            new Dictionary<Type, object>();

        public static void SetService<T>(T value) where T : class
        {
            var typeValue = value.GetType();
            if (!ServiceContainer.ContainsKey(typeValue))
            {
                ServiceContainer[typeValue] = value;
            }
        }
 
        public static T Resolve<T>()
        {
            return (T)ServiceContainer[typeof(T)];
        }
    }
}