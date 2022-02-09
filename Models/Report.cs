namespace scat_chat_api.Models
{
    public class Report
    {
        public int PostId { get; set; }
        public Post Post { get; set; }    
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Offensive { get; set; } = false;
        public bool Inappropriate { get; set; } = false;
        public bool Spam { get; set; } = false;
        public bool Other { get; set; } = false;
        public Instant TimeCreated {get; set;}

    }
}