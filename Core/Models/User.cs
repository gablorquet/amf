using Microsoft.SqlServer.Server;

namespace Core.Models
{
    public abstract class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
