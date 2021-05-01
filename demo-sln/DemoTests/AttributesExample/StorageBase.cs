using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoTests.AttributesExample {
    public class StorageBase {
        
        /// <summary>
        /// Get all properties decorated with <see cref="CsvInfoAttribute"/>.
        /// </summary>
        public static Dictionary<PropertyInfo, CsvInfoAttribute> GetCsvProperties<T>() => typeof(T)
            .GetProperties()
            .Where(prop => prop.GetCustomAttribute<CsvInfoAttribute>() is { })
            .ToDictionary(
                keySelector: prop => prop,
                elementSelector: prop => prop.GetCustomAttribute<CsvInfoAttribute>());
    }
}