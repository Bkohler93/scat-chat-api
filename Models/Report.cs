namespace scat_chat_api.Models
{
    public class Report
    {
        public int ScatId { get; set; }
        public int UserId { get; set; }
        public bool Offensive { get; set; } = false;
        public bool Inappropriate { get; set; } = false;
        public bool Spam { get; set; } = false;
        public bool Other { get; set; } = false;

    }
}