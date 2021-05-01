using System;

namespace DemoTests.AttributesExample {
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvInfoAttribute : Attribute {
        public CsvInfoAttribute(string headerText, Type formatter) {
            if (!formatter.IsAssignableTo(typeof(IValueFormatter))) throw new ArgumentException($"Must implement {nameof(IValueFormatter)}", nameof(formatter));
            HeaderText = headerText;
            Formatter = Activator.CreateInstance(formatter) as IValueFormatter;
        }
        
        public string HeaderText { get; }
        
        public IValueFormatter Formatter { get; }
    }
}