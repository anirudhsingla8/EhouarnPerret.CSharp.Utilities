using System;
using System.Linq.Expressions;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    internal static class FastPropertyFactory
    {
        public static Func<TInstance, TProperty> CreateGetter<TInstance, TProperty>(string propertyName)
        {
            var instanceParameterExpression = Expression.Parameter(typeof(TInstance), "value");

            var propertyExpression = Expression.Property(instanceParameterExpression, propertyName);

            var expression = propertyExpression.Type == typeof(TProperty) ? propertyExpression : (Expression)Expression.Convert(propertyExpression, typeof(TProperty));

            var getter = Expression.Lambda<Func<TInstance, TProperty>>(expression, instanceParameterExpression).Compile();

            return getter;
        }

        public static Action<TInstance, TProperty> CreateSetter<TInstance, TProperty>(string propertyName)
        {
            var instanceParameterExpression = Expression.Parameter(typeof(TInstance));

            var valueParameterExpression = Expression.Parameter(typeof(TProperty), propertyName);

            var propertyExpression = Expression.Property(instanceParameterExpression, propertyName);

            var expression = propertyExpression.Type == typeof(TProperty) ? propertyExpression : (Expression)Expression.Convert(propertyExpression, typeof(TProperty));

            var setter = Expression.Lambda<Action<TInstance, TProperty>>(Expression.Assign(propertyExpression, valueParameterExpression), instanceParameterExpression, valueParameterExpression).Compile();

            return setter;
        }
    }
}