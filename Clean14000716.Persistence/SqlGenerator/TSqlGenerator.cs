using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Clean14000716.Common.Utilities
{
    public static class SqlGenerator
    {
        private static  IEnumerable<string> GetUpdateableProperties<T>(T entity)
        {
            var res = entity.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .Where(property =>
                    property.CanWrite &&
                    //!property.PropertyType.GetInterfaces().Contains(typeof(IEntity)) &&
                    !(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                );

            foreach (var propertyInfo in res)
            {
                yield return propertyInfo.Name;
            }
        }
        public static string InsertCommandFor<T>(T type)
        {
            var list = GetUpdateableProperties(type);
            var name = string.Join(",", list.ToArray());
            name = $"INSERT INTO school({name}) VALUES( )"; 
            return name;
        }
    }
}