
using BlazorBlog.Domain.Articles;
using BlazorBlog.Infrastructure.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
