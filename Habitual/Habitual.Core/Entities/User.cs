﻿namespace Habitual.Core.Entities
{
    public class User
    {
        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public int Points { get; set; }
    }
}
