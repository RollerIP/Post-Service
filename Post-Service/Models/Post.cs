
using System.ComponentModel.DataAnnotations;

namespace Post_Service.Models
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; private set; }
        public string Text { get; private set; }
        public DateTime PostingDate { get; private set; }

        public Post() { }

        public Post(User user, string text, DateTime postingDate)
        {
            User = user;
            Text = text;
            PostingDate = postingDate;
        }
    }
}
