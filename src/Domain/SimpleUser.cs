using System;
using System.ComponentModel.DataAnnotations;

namespace Domain {
    /*
     * Don't create domain models like this.
     * 
     * bad case of primitive obsession
     * Values can be set to anything
     */
    public class SimpleUser {
        private SimpleUser() {
            // make EF core happy
        }
        
        public SimpleUser(string username) {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException("Cannot be null");
            if (username.Length > 100) throw new ArgumentException("Cannot exceed 100 characters.");
            Username = username;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}