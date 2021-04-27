using System;

namespace Domain {
    /*
     * Proper encapsulation.
     *
     * This is the type of domain model you'd like...
     * But it's obviously over-simplified.
     */
    public class User {
        private Username username;
        
        public User(Username username) {
            Id = Guid.NewGuid();
            this.username = username;
        }
        
        public Guid Id { get; }
        
        public string Username => username.Value;

        public void ChangeUsername(Username newUsername) => this.username = newUsername;
    }
}