using CodeLife.web.Data;
using CodeLife.web.Models.Domain;
using CodeLife.web.Repositories.Interfaces;

namespace CodeLife.web.Repositories.Implementations
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly CodeLifeDbContext codeLifeDbContext;

        public BlogPostRepository(CodeLifeDbContext codeLifeDbContext)
        {
            this.codeLifeDbContext = codeLifeDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
           await codeLifeDbContext.AddAsync(blogPost);
            await codeLifeDbContext.SaveChangesAsync();
            return blogPost;
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
