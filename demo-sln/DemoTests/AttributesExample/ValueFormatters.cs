namespace DemoTests.AttributesExample {
    public interface IValueFormatter {
        string Format(object value);
    }
    
    /// <summary>
    /// Don't perform any value formatting.
    /// </summary>
    public class NoFormatting : IValueFormatter {
        public string Format(object value) => value?.ToString() ?? "";
    }

    /// <summary>
    /// Place quotes around string. Hello => "Hello"
    /// </summary>
    public class EscapedString : IValueFormatter {
        public string Format(object value) => $"\"{value}\"";
    }

    public class MoneyFormatting : IValueFormatter {
        public string Format(object value) => value is not decimal ? value.ToString() : $"{value:N0}";
    }
}