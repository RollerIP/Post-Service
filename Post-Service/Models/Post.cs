namespace Post_Service.Models
{
    public class Post
    {
        public Guid id { get; } 
        public User user { get; private set; }
        public string text { get; private set; }
        public List<string> imageUrls { get; private set; }

        public Post(User user, string text, List<string> imageUrls)
        {
            this.id = Guid.NewGuid();
            this.user = user;
            this.text = text;
            this.imageUrls = imageUrls;
        }
    }
}
