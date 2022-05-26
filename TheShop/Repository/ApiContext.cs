using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Repository
{
    public class ApiContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
            LoadArticles();
        }

        public void LoadArticles()
        {
            Article article = new Article("Article from supplier1", 458, 1);
            Articles.Add(article);
            article = new Article("Article from supplier2", 459, 1);
            Articles.Add(article);
            article = new Article("Article from supplier3", 460, 1);
            Articles.Add(article);
        }

        public async Task<List<Article>> GetArticles()
        {
            return Articles.Local.ToList<Article>();
        }

        public async Task<Article> GetById(int id)
        {
            return Articles.Local.FirstOrDefault(a => a.ArticleId == id);
        }

        public async Task Save(Article article)
        {
                Articles.Local.Clear();
                Articles.Local.Add(article);
        }
    }

}
