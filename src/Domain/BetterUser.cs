using System;

namespace Domain {
    
    /*
     * Slightly better.
     * But accessing the Username value is awkward
     */
    public class BetterUser {
        public BetterUser(Username username) {
            Id = Guid.NewGuid();
            Username = username;
        }
        
        public Guid Id { get; }
        public Username Username { get; private set; }

        public void ChangeUsername(Username username) => Username = username;
    }
}