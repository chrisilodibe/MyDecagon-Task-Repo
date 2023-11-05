using CodeLife.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeLife.web.Data
{
    public class CodeLifeDbContext : DbContext
    {
        public CodeLifeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
