using Microsoft.EntityFrameworkCore;

namespace NWBlog.EntityFrameworkDemo.Api.Data
{
    public class DefaultContext : DbContext
    {
        private readonly string _username;
        private readonly bool _userIsAdmin;

        public DbSet<Message> Messages { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options, string username, bool userIsAdmin) : base(options)
        {
            _username = username;
            _userIsAdmin = userIsAdmin;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // only messages sent by the currently signed in user will be retrieved from the database
            modelBuilder.Entity<Message>().HasQueryFilter(m => m.SentByUsername == _username);

            // OR

            // messages sent by the currently signed in user will be retrieved, but only if the user is an admin
            modelBuilder.Entity<Message>().HasQueryFilter(m => m.SentByUsername == _username && _userIsAdmin);
        }
    }
}
