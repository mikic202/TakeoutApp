﻿namespace TakeoutWebApp.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }  // zazwyczaj hasło ma inny typ
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
