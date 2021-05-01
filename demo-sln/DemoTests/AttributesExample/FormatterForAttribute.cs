using System;

namespace DemoTests.AttributesExample {
    [AttributeUsage(AttributeTargets.Class)]
    public class FormatterForAttribute : Attribute {
        public FormatterForAttribute(FileFormat fileFormat) {
            FileFormat = fileFormat;
        }
        
        public FileFormat FileFormat { get; }
    }
}