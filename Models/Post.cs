namespace scat_chat_api.Models
{
    public class Post 
    {
        public int Id { get; set; }
        public string Author {get; set;}
        public string Text { get; set; }
        public string Color { get; set; }
        public Instant TimeCreated { get; set; }
        public int UserId {get; set;}
        public User User { get; set; }
    }
}