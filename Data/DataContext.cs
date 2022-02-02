using Microsoft.EntityFrameworkCore;
using scat_chat_api.Models;

namespace scat_chat_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Scat> Scats {get; set;}
    }
}