using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShop.Exceptions;
using TheShop.Interfaces;
using TheShop.Model;

namespace TheShop.Services
{
    public class DatabaseDriver : IDatabaseService
    {
        private readonly List<Article> _articles = new List<Article>();
        private readonly ILogger _logger;
        public DatabaseDriver(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<Article> GetById(int id)
        {
            return _articles.SingleOrDefault(x => x.Id == id) ?? throw new ArticleNotFoundException(id.ToString());
        }

        public async Task Save(Article article)
        {
            try
            {
                _articles.Add(article);
            }
            catch (Exception ex)
            {
                await _logger.Error("Could not save article with id=" + article.Id + ": " + ex.Message);
                throw new Exception("Could not save article with id=" + article.Id + ": " + ex.Message);
            }

        }
    }
}
