using System;
using System.Threading.Tasks;
using TheShop.Exceptions;
using TheShop.Interfaces;
using TheShop.Model;
using TheShop.Repository;

namespace TheShop.Services
{
    public class ShopService : IShopService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger _logger;
        private readonly ApiContext _apiContext;
        public ShopService(IDatabaseService databaseService, ILogger logger, ApiContext apiContext)
        {
            _databaseService = databaseService;
            _logger = logger;
            _apiContext = apiContext;
        }
        public async Task<Article> OrderArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article
            var articleList = await _apiContext.GetArticles();
            
            if (articleList == null) throw new ArticleNotFoundException($"No articles found");

            var articleExists = articleList.Exists(x => x.ArticleId == id);
            
            var article = articleExists switch
            {
                false => throw new ArticleNotFoundException($"Article with Id= {id} don't exists in Inventory"),
                true => articleList.Find(x => x.ArticleId == id && maxExpectedPrice < x.ArticlePrice)
            };
            
            return article;

            #endregion
        }

        public async Task SellArticle(Article article)
        {
            #region selling article

            if (article == null) throw new Exception("Article can not be null");

            await _logger.Debug("Trying to sell article with articleId= " + article.ArticleId);

            article.IsSold = true;

            try
            {
                await _apiContext.Save(article);
                await _logger.Info("Article with articleId= " + article.ArticleId + " is sold.");
            }
            catch (Exception ex)
            {
                await _logger.Error("Could not save article with articleId=" + article.ArticleId + ": " + ex.Message);
                throw new Exception("Could not save article with articleId=" + article.ArticleId + ": " + ex.Message);
            }


            #endregion
        }

        public async Task<Article> GetById(int id)
        {
            return await _apiContext.GetById(id) ?? throw new ArticleNotFoundException(id.ToString());
        }
    }




}
