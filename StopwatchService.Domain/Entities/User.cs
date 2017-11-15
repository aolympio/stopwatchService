using System;

namespace StopwatchService.Domain.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreationDate { get; set; }
    }
}