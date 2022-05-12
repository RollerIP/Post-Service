
using System.ComponentModel.DataAnnotations;

namespace Post_Service.Models
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime PostingDate { get; set; }

        public Post() { }

        public Post(User user, string text, DateTime postingDate)
        {
            User = user;
            Text = text;
            PostingDate = postingDate;
        }
    }
}
