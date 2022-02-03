namespace scat_chat_api.Models
{
    public class Scat
    {
        public int Id { get; set; }
        public string Author {get; set;}
        public string Text { get; set; }
        public string Color { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public int NumLikes { get; set; } = 0;
        public User User { get; set; }
    }
}