namespace scat_chat_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set;} 
        public Instant TimeCreated {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Post> Posts{get; set;}
    }
}