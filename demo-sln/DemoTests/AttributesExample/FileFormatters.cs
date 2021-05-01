using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DemoTests.AttributesExample {
    public interface IFileFormatter {
        string Format<T>(IEnumerable<T> values) where T : StorageBase;
    }


    [FormatterFor(FileFormat.PlainText)]
    public class PlainTextFormatter : IFileFormatter {
        public string Format<T>(IEnumerable<T> values) where T : StorageBase {
            var builder = new StringBuilder();

            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo last = properties.Last();
            foreach (T storageType in values) {
                foreach (PropertyInfo t in properties) {
                    string endCharacter = t.Equals(last) ? Environment.NewLine : " ";
                    builder.Append($"{t.Name}: {t.GetValue(storageType)}{endCharacter}");
                }
            }

            return builder.ToString();
        }
    }
    
    [FormatterFor(FileFormat.Csv)]
    public class CsvFormatter : IFileFormatter {
        public string Format<T>(IEnumerable<T> values) where T : StorageBase {
            var builder = new StringBuilder();

            Dictionary<PropertyInfo, CsvInfoAttribute> csvProperties = StorageBase.GetCsvProperties<T>();
            if (csvProperties.Count == 0) return builder.ToString();

            var last = csvProperties.Last();
            foreach (KeyValuePair<PropertyInfo,CsvInfoAttribute> csvInfo in csvProperties) {
                builder.Append($"{csvInfo.Value.HeaderText},");
                if (last.Key != csvInfo.Key) continue;
                
                builder.Append(Environment.NewLine);
                break;
            }

            PropertyInfo[] typeProperties = typeof(T).GetProperties();
            foreach (T storageType in values) {
                for (int i = 0; i < typeProperties.Length; i++) {
                    object value = csvProperties.Keys.ElementAt(i).GetValue(storageType);
                    CsvInfoAttribute attr = csvProperties[typeProperties[i]];

                    string endCharacter = attr.Equals(last.Value) ? Environment.NewLine : ",";
                    
                    builder.Append($"{attr.Formatter.Format(value)}{endCharacter}");
                }
            }
            
            return builder.ToString();
        }
    }
}