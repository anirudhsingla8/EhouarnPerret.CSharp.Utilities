using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    internal static class FastPropertyRepository<TInstance, TProperty>
    {
        static FastPropertyRepository()
        {
            _getters = new ConcurrentDictionary<string, Func<TInstance, TProperty>>();
            _setters = new ConcurrentDictionary<string, Action<TInstance, TProperty>>();
        }

        private static IDictionary<string, Func<TInstance, TProperty>> _getters;
        private static IDictionary<string, Action<TInstance, TProperty>> _setters;

        public static Func<TInstance, TProperty> GetGetter(string propertyName)
        {

            if (!_getters.TryGetValue(propertyName, out Func<TInstance, TProperty> getter))
            {
                getter = FastPropertyFactory.CreateGetter<TInstance, TProperty>(propertyName);
                _getters[propertyName] = getter;
            }

            return getter;
        }

        public static Action<TInstance, TProperty> GetSetter(string propertyName)
        {
            if (!_setters.TryGetValue(propertyName, out Action<TInstance, TProperty> setter))
            {
                setter = FastPropertyFactory.CreateSetter<TInstance, TProperty>(propertyName);
                _setters[propertyName] = setter;
            }

            return setter;
        }
    }
}