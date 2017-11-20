using System;

namespace StopwatchService.Domain.Structs
{
    /// <summary>
    /// Responsible for carry user data info since Web Layer up to the Data Access one.
    /// This Wrapper was create also to avoid dependencies of Stoage Azure at Web Layer
    /// due to the User class need to inherit from TEntity(Azure class).
    /// </summary>
    public struct UserWrapper
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreationDate { get; set; }
    }
}