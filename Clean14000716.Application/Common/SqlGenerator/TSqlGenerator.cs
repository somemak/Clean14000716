using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Application.Common.SqlGenerator
{
    public static class SqlGenerator
    {
        private static IEnumerable<string> GetUpdateableProperties<T>(T entity)
        {
            var res = entity.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .Where(property =>
                    property.CanWrite &&
                    property.Name != "Id" &&
                    !property.PropertyType.GetInterfaces().Contains(typeof(IEntity)) &&
                    !(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                );

            foreach (var propertyInfo in res)
            {
                yield return propertyInfo.Name;
            }
        }

        private static IEnumerable<string> GetUpdateableProperties1<T>(T entity)
        {
            var res = entity.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .Where(property =>
                    property.CanWrite


                );

            foreach (var propertyInfo in res)
            {
                yield return propertyInfo.Name;
            }
        }
        public static string CreateInsertCommand<T>(this object o, T type)
        {
            var list = string.Join(",", GetUpdateableProperties(o).ToArray());
            var list1 = string.Join(",", GetUpdateableProperties(type).ToArray());

            return $"INSERT INTO school({list}) VALUES({list1})";
        }

      

    }
}