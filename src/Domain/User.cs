using System;

namespace Domain {
    public class User {
        public User(Username username) {
            Username = username;
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; }
        public Username Username { get; private set; }

        public void ChangeUsername(Username username) => Username = username;
    }
}