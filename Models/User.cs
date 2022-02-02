using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scat_chat_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "brett@gmail.com";
        public byte[] PasswordHash { get; set; } = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20};
        public byte[] PasswordSalt { get; set; } = new byte[] {0x20, 0x20, 0x20, 0x20, 0x20, 0x20};
    }
}