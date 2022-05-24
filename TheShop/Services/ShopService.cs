using System;
using System.Threading.Tasks;
using TheShop.Exceptions;
using TheShop.Interfaces;
using TheShop.Model;

namespace TheShop.Services
{
    public class ShopService : IShopService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger _logger;
        private readonly IInventory _inventoryService;
        public ShopService(IDatabaseService databaseService, ILogger logger, IInventory inventoryService)
        {
            _databaseService = databaseService;
            _logger = logger;
            _inventoryService = inventoryService;
        }
        public async Task<Article> OrderArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article

            var articleExists = _inventoryService.ArticleInInventory(id);
            var article = await articleExists switch
            {
                false => throw new ArticleNotFoundException($"Article with Id= {id} don't exists in Inventory"),
                true => _inventoryService.ListOfArticles().Result.Find(x => x.Id == id && maxExpectedPrice < x.ArticlePrice)
            };
            return article;

            #endregion
        }

        public async Task SellArticle(Article article)
        {
            #region selling article

            if (article == null) throw new Exception("Article can not be null");
            await _logger.Debug("Trying to sell article with id=" + article.Id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;

            await _databaseService.Save(article);
            await _logger.Info("Article with id=" + article.Id + " is sold.");

            #endregion
        }

        public async Task<Article> GetById(int id)
        {
            return await _databaseService.GetById(id);
        }
    }




}
