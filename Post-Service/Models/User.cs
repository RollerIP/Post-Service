using System.ComponentModel.DataAnnotations;

namespace Post_Service.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; private set; }
        public string AvatarUrl { get; private set; }
        
        public User() { }

        public User(string username, string avatarUrl)
        {
            Username = username;
            AvatarUrl = avatarUrl;
        }
    }
}
