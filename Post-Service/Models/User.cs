namespace Post_Service.Models
{
    public class User
    {
        public Guid id { get; }
        public string username { get; private set; }
        public string avatarUrl { get; private set; }

        public User(string username, string avatarUrl)
        {
            this.id = Guid.NewGuid();
            this.username = username;
            this.avatarUrl = avatarUrl;
        }
    }
}
