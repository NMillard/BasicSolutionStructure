using System;

namespace DemoTests.AttributesExample {
    public class AvailableFormat : Attribute {
        public AvailableFormat(FileFormat format) {
            Format = format;
        }
        
        public FileFormat Format { get; }
    }
    
    public enum FileFormat {
        PlainText,
        Csv,
    }
}