using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DemoTests.AttributesExample {
    public static class FormatterExtensions {
        public static IFileFormatter? PickFormatter(this IEnumerable<IFileFormatter> formatters, FileFormat format) => formatters
            .SingleOrDefault(f => f.GetType().GetCustomAttribute<FormatterForAttribute>()?.FileFormat == format);
    }
}