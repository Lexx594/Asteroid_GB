using System;
using System.Collections.Generic;
namespace Asteroids.ServiceLocator
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _serviceŅontainer = new Dictionary<Type, object>();
       
        public static void SetService<T>(T value) where T : class
        {
            var typeValue = typeof(T);
            if (!_serviceŅontainer.ContainsKey(typeValue))
            {
                _serviceŅontainer[typeValue] = value;
            }
        }
        
        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_serviceŅontainer.ContainsKey(type))
            {
                return (T)_serviceŅontainer[type];
            }
            return default;
        }
    }
}
