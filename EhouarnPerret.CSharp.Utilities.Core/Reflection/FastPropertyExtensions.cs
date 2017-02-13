namespace EhouarnPerret.CSharp.Utilities.Core.Reflection
{
    public static class FastPropertyExtensions
    {
        public static TProperty Get<TInstance, TProperty>(this TInstance instance, string propertyName)
        {
            return FastPropertyRepository<TInstance, TProperty>.GetGetter(propertyName)(instance);
        }

        public static void Set<TInstance, TProperty>(this TInstance instance, string propertyName, TProperty propertyValue)
        {
            FastPropertyRepository<TInstance, TProperty>.GetSetter(propertyName)(instance, propertyValue);
        }
    }
}