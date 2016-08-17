using System;
using System.Reflection;

namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public static class ReflectionExtensions
    {
        public static Type GetCompileTimeType<TSource>(this TSource source)
        {
            var type = typeof (TSource);

            return type;
        }

        public static FieldInfo GetFieldInfo<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var fieldInfo = source.GetCompileTimeType().GetField(name, accessModifier.ToInstanceBindingFlags());

            return fieldInfo;
        }
        public static Object GetFieldValue<TSource> (this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var fieldInfo = source.GetFieldInfo (name, accessModifier);

            var value = fieldInfo.GetValue (source);

            return value;
        }
        public static void SetFieldValue<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier, Object value)
        {
            var fieldInfo = source.GetFieldInfo(name, accessModifier);

            fieldInfo.SetValue(source, value);
        }

        public static PropertyInfo GetPropertyInfo<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var propertyInfo = source.GetCompileTimeType().GetProperty(name, accessModifier.ToInstanceBindingFlags());

            return propertyInfo;
        }
        public static Object GetPropertyValue<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            var value = propertyInfo.GetValue(source);

            return value;
        }
        public static Object GetIndexedPropertyValue<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier, params Object[] index)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            var value = propertyInfo.GetValue(source, index);

            return value;
        }

        public static MethodInfo GetPropertySetterMethodInfo<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            var methodInfo = propertyInfo.GetSetMethod(accessModifier.IsIn(SimpleAccessModifiers.Both, SimpleAccessModifiers.NonPublic));

            return methodInfo;
        }
        public static MethodInfo GetPropertyGetterMethodInfo<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            var methodInfo = propertyInfo.GetGetMethod(accessModifier.IsIn(SimpleAccessModifiers.Both, SimpleAccessModifiers.NonPublic));

            return methodInfo;
        }

        public static void SetPropertyValue<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier, Object value)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            propertyInfo.SetValue(source, value);
        }
        public static void SetIndexedPropertyValue<TSource>(this TSource source, String name, SimpleAccessModifiers accessModifier, Object value, params Object[] index)
        {
            var propertyInfo = source.GetPropertyInfo(name, accessModifier);

            propertyInfo.SetValue(source, value, index);
        }

        public static EventInfo GetEventInfo<T>(this T source, String name, SimpleAccessModifiers accessModifier)
        {
            var eventInfo = source.GetCompileTimeType().GetEvent(name, accessModifier.ToInstanceBindingFlags());

            return eventInfo;
        }

        public static MethodInfo GetMethodInfo<T>(this T source, String name, SimpleAccessModifiers accessModifier)
        {
            var methodInfo = source.GetCompileTimeType().GetMethod(name, accessModifier.ToInstanceBindingFlags());

            return methodInfo;
        }
        public static TResult InvokeMethod<TSource, TResult>(this TSource source, String name, SimpleAccessModifiers accessModifier, params Object[] parameters)
        {
            var methodInfo = source.GetMethodInfo(name, accessModifier);

            return (TResult)methodInfo.Invoke(source, parameters);
        }
    }
}