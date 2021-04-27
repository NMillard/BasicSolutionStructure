using System;

namespace Domain {
    
    public record Username {
        private const int MaxUsernameLength = 100;

        public Username(string value) {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("A username cannot be empty", nameof(value));
            if (value.Length > MaxUsernameLength)
                throw new ArgumentException($"Username is too long. Max lenght is {MaxUsernameLength}", nameof(value));
            Value = value;
        }

        public string Value { get; }

        public static implicit operator Username(string value) => new Username(value);
    }
}