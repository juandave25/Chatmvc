using System.Data.Entity;

namespace Chatmvc.Models
{
    public class Context : DbContext
    {
        public Context() : base("connection")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}